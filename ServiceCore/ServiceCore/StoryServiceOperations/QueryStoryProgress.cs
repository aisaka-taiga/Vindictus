﻿using System;
using UnifiedNetwork.Cooperation;

namespace ServiceCore.StoryServiceOperations
{
	[Serializable]
	public sealed class QueryStoryProgress : Operation
	{
		public override OperationProcessor RequestProcessor()
		{
			return new OkOrFailProcessor(this);
		}
	}
}
