﻿using System;
using System.Collections.Generic;
using System.Net;
using Devcat.Core;
using Devcat.Core.Net;
using Devcat.Core.Threading;
using Nexon.CafeAuthJPN.Packets;
using Utility;

namespace Nexon.CafeAuthJPN
{
	public class Connection : IDisposable
	{
		public void SetGameSN(GameSN gameSN)
		{
			this.gameSN = gameSN;
		}

		public Connection(GameSN gameSN)
		{
			this.connection.ConnectionFail += this.OnConnectionFail;
			this.connection.ConnectionSucceed += this.connection_ConnectionSucceed;
			this.connection.Disconnected += this.OnDisconnected;
			this.connection.ExceptionOccur += this.OnExceptionOccur;
			this.connection.PacketReceive += this.connection_PacketReceive;
			this.gameSN = gameSN;
		}

		private void connection_ConnectionSucceed(object sender, EventArgs e)
		{
			Log<Connection>.Logger.Info("connection_ConnectionSucceed");
			this.thread.Enqueue(Job.Create(new Action(this.Initialize)));
		}

		public bool Connected
		{
			get
			{
				return this.connection.Connected;
			}
		}

		public event EventHandler<EventArgs<Exception>> ConnectionFail;

		public event EventHandler<EventArgs> Disconnected;

		public event EventHandler<EventArgs<Exception>> ExceptionOccur;

		public event Action<LoginResponse> MessageReceived;

		public void Dispose()
		{
			if (this.connection != null)
			{
				this.connection.ConnectionFail -= this.OnConnectionFail;
				this.connection.Disconnected -= this.OnDisconnected;
				this.connection.ExceptionOccur -= this.OnExceptionOccur;
				this.connection.PacketReceive -= this.connection_PacketReceive;
				if (this.connection.Connected)
				{
					this.connection.Disconnect();
				}
				this.connection = null;
			}
		}

		public void Connect(JobProcessor thread, IPEndPoint endPoint, byte domainSN, string domainName)
		{
			this.thread = thread;
			this.domainSN = domainSN;
			this.domainName = domainName;
			this.connection.Connect(this.thread, endPoint.Address, endPoint.Port, new PacketAnalyzer());
		}

		private void OnConnectionFail(object sender, EventArgs<Exception> e)
		{
			if (this.ConnectionFail != null)
			{
				Log<Connection>.Logger.InfoFormat("OnConnectionFail {0}", e.ToString());
				this.ConnectionFail(sender, e);
			}
		}

		private void OnDisconnected(object sender, EventArgs e)
		{
			if (this.Disconnected != null)
			{
				Log<Connection>.Logger.InfoFormat("OnDisconnected {0}", e.ToString());
				this.Disconnected(sender, e);
			}
		}

		private void OnExceptionOccur(object sender, EventArgs<Exception> e)
		{
			if (this.ExceptionOccur != null)
			{
				Log<Connection>.Logger.InfoFormat("OnExceptionOccur {0}", e.ToString());
				this.ExceptionOccur(sender, e);
			}
		}

		private void connection_PacketReceive(object sender, EventArgs<ArraySegment<byte>> e)
		{
			Log<Connection>.Logger.Info("connection_PacketReceive");
			Packet packet = new Packet(e.Value);
			LoginResponse arg = new LoginResponse(ref packet);
			this.thread.Enqueue(Job.Create<LoginResponse>(new Action<LoginResponse>(this.Process), arg));
		}

		private void Transmit(Packet packet)
		{
			this.connection.Transmit<Packet>(packet);
		}

		private AsyncResult Transmit(Packet packet, string nexonID, string characterID, AsyncCallback callback, object state)
		{
			Log<Connection>.Logger.Info("Transmit - IN");
			AsyncResult asyncResult = new AsyncResult(nexonID, characterID, callback, state);
			Connection.Key key = new Connection.Key
			{
				NexonID = asyncResult.NexonID,
				CharacterID = asyncResult.CharacterID
			};
			if (!this.Connected)
			{
				asyncResult.Complete(true);
				Log<Connection>.Logger.Info("Transmit - not Connected");
				return asyncResult;
			}
			if (this.queries.ContainsKey(key))
			{
				asyncResult.Complete(true);
				Log<Connection>.Logger.Info("Transmit - ContainsKey");
				return asyncResult;
			}
			this.queries.Add(key, asyncResult);
			this.Transmit(packet);
			Log<Connection>.Logger.Info("Transmit - OUT");
			return asyncResult;
		}

		private void Process(LoginResponse response)
		{
			Connection.Key key = new Connection.Key
			{
				NexonID = response.NexonID,
				CharacterID = response.CharacterID
			};
			AsyncResult asyncResult;
			if (this.queries.TryGetValue(key, out asyncResult) && response.Result != Result.Message)
			{
				this.queries.Remove(key);
				asyncResult.Response = response;
				asyncResult.Complete();
				return;
			}
			if (this.MessageReceived != null)
			{
				this.MessageReceived(response);
			}
		}

		private void Initialize()
		{
			Initialize initialize = new Initialize(this.gameSN, this.domainSN, this.domainName);
			this.Transmit(initialize.Serialize());
			Scheduler.Schedule(this.thread, Job.Create(new Action(this.Heartbeat)), new TimeSpan(0, 0, 30));
		}

		private void Heartbeat()
		{
			Alive alive = new Alive();
			this.Transmit(alive.Serialize());
			Scheduler.Schedule(this.thread, Job.Create(new Action(this.Heartbeat)), new TimeSpan(0, 0, 30));
		}

		public IAsyncResult BeginLogin(string nexonID, string characterID, IPAddress localAddress, IPAddress remoteAddress, bool canTry, bool isTrial, MachineID machineID, ICollection<int> gameRoomClients, AsyncCallback callback, object state)
		{
			Login login = new Login(nexonID, characterID, localAddress, remoteAddress, canTry, isTrial, machineID, gameRoomClients);
			return this.Transmit(login.Serialize(), nexonID, characterID, callback, state);
		}

		public LoginResponse EndLogin(IAsyncResult asyncResult)
		{
			if (!(asyncResult is AsyncResult))
			{
				return null;
			}
			AsyncResult asyncResult2 = (AsyncResult)asyncResult;
			return asyncResult2.Response as LoginResponse;
		}

		public void Logout(string nexonID, string characterID, IPAddress remoteAddress, bool canTry)
		{
			Logout logout = new Logout(nexonID, characterID, remoteAddress, canTry);
			this.Transmit(logout.Serialize());
			Connection.Key key = new Connection.Key
			{
				NexonID = nexonID,
				CharacterID = characterID
			};
			AsyncResult asyncResult;
			if (this.queries.TryGetValue(key, out asyncResult))
			{
				this.queries.Remove(key);
				asyncResult.Response = null;
				asyncResult.Complete();
			}
		}

		private TcpClient connection = new TcpClient();

		private JobProcessor thread;

		private GameSN gameSN;

		private byte domainSN;

		private string domainName;

		private IDictionary<Connection.Key, AsyncResult> queries = new Dictionary<Connection.Key, AsyncResult>();

		private struct Key
		{
			public string NexonID;

			public string CharacterID;
		}
	}
}
