using System;

namespace TestUtility
{
	[AttributeUsage(AttributeTargets.Method)]
	public class TestInfoAttribute : Attribute
	{
		public TestResult Result { get; set; }
	}
}
