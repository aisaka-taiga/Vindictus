﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace NPL.SSO.com.nexon.auth
{
	[DebuggerStepThrough]
	[GeneratedCode("System.Xml", "2.0.50727.5476")]
	[XmlType(Namespace = "http://tempuri.org/")]
	[DesignerCategory("code")]
	[Serializable]
	public class CheckIDnPasswordResult
	{
		public int nErrorCode
		{
			get
			{
				return this.nErrorCodeField;
			}
			set
			{
				this.nErrorCodeField = value;
			}
		}

		public string strErrorMessage
		{
			get
			{
				return this.strErrorMessageField;
			}
			set
			{
				this.strErrorMessageField = value;
			}
		}

		private int nErrorCodeField;

		private string strErrorMessageField;
	}
}
