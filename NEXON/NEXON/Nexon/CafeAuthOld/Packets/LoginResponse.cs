﻿using System;
using System.Text;

namespace Nexon.CafeAuthOld.Packets
{
	[Serializable]
	public sealed class LoginResponse
	{
		public string NexonID { get; internal set; }

		public string CharacterID { get; internal set; }

		public Result Result { get; internal set; }

		public AddressDesc AddressDesc { get; internal set; }

		public AccountDesc AccountDesc { get; internal set; }

		public Option Option { get; internal set; }

		public int Argument { get; internal set; }

		public bool IsCafe { get; internal set; }

		public char PCRoomLevel { get; internal set; }

		internal LoginResponse(ref Packet packet)
		{
			this.NexonID = packet.ReadString();
			this.CharacterID = packet.ReadString();
			this.Result = (Result)packet.ReadByte();
			this.AddressDesc = (AddressDesc)packet.ReadByte();
			this.AccountDesc = (AccountDesc)packet.ReadByte();
			this.Option = (Option)packet.ReadByte();
			this.Argument = packet.ReadInt32();
			this.IsCafe = packet.ReadBoolean();
			this.PCRoomLevel = (char)packet.ReadByte();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{ NexonID = ");
			stringBuilder.Append(this.NexonID);
			stringBuilder.Append(", CharacterID = ");
			stringBuilder.Append(this.CharacterID);
			stringBuilder.Append(", Result = ");
			stringBuilder.Append(this.Result);
			stringBuilder.Append(", AddressDesc = ");
			stringBuilder.Append(this.AddressDesc);
			stringBuilder.Append(", AccountDesc = ");
			stringBuilder.Append(this.AccountDesc);
			stringBuilder.Append(", Option = ");
			stringBuilder.Append(this.Option);
			stringBuilder.Append(", Argument = ");
			stringBuilder.Append(this.Argument);
			stringBuilder.Append(", IsCafe = ");
			stringBuilder.Append(this.IsCafe);
			stringBuilder.Append(" }");
			return base.ToString();
		}
	}
}
