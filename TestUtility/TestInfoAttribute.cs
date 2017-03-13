using System;

namespace TestUtility
{
	[AttributeUsage(AttributeTargets.Method)]
	public class TestInfoAttribute : Attribute
	{
		public int ViolationCount { get; set; }
	}
}
