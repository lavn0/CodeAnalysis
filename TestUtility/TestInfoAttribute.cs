﻿using System;

namespace TestUtility
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public class TestInfoAttribute : Attribute
	{
		public string TargetRuleName { get; set; }
		public int ViolationCount { get; set; }
		public string ResolutionName { get; set; }
	}
}
