using System;

namespace TestUtility
{
	[AttributeUsage(AttributeTargets.Method)]
	public class TestInfoAttribute : Attribute
	{
		public string TargetRuleName { get; set; }
		public int ViolationCount { get; set; }
	}
}
