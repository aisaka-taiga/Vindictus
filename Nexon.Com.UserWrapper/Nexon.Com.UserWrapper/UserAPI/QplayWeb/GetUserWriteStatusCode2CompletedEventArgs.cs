﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Nexon.Com.UserWrapper.UserAPI.QplayWeb
{
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.3053")]
	[DebuggerStepThrough]
	public class GetUserWriteStatusCode2CompletedEventArgs : AsyncCompletedEventArgs
	{
		internal GetUserWriteStatusCode2CompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		public int Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[0];
			}
		}

		public byte n1WriteStatusCode
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (byte)this.results[1];
			}
		}

		public int n4NexonSN
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[2];
			}
		}

		private object[] results;
	}
}
