using System.Diagnostics;

namespace StyleCopCustomUnitTest.TestSources
{
	public class ShortenAttributeName
	{
		[DebuggerStepThrough]
		public string OK()
		{
			return string.Empty;
		}

		// ERROR(4,31) 属性指定時の省略されていない末尾名Attribute
		[DebuggerStepThroughAttribute]
		public string NG1()
		{
			return string.Empty;
		}

		// ERROR(4,33) 属性指定時の省略されていない末尾名Attribute
		// ERROR(36,84) 属性指定時の省略されていない末尾名Attribute
		[DebuggerStepThroughAttribute(), System.Diagnostics.DebuggerNonUserCodeAttribute()]
		public string NG2()
		{
			return string.Empty;
		}
	}
}
