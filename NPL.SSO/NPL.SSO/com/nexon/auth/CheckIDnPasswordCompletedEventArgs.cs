﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace NPL.SSO.com.nexon.auth
{
	[DesignerCategory("code")]
	[GeneratedCode("System.Web.Services", "2.0.50727.5420")]
	[DebuggerStepThrough]
	public class CheckIDnPasswordCompletedEventArgs : AsyncCompletedEventArgs
	{
		internal CheckIDnPasswordCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}

		public CheckIDnPasswordResult Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (CheckIDnPasswordResult)this.results[0];
			}
		}

		private object[] results;
	}
}
