﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Nexon.Com.UserWrapper.UserAPI.NexonStick
{
	[DebuggerStepThrough]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	[DesignerCategory("code")]
	public class CheckMatchUserSsn_FullCompletedEventArgs : AsyncCompletedEventArgs
	{
		internal CheckMatchUserSsn_FullCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
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

		private object[] results;
	}
}
