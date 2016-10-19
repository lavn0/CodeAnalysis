using System.Diagnostics;

namespace StyleCopCustomUnitTest.Resources
{
	public class ShortenAttributeNameTestClass
	{
		[DebuggerStepThrough]
		public string OK()
		{
			return string.Empty;
		}

		[DebuggerStepThroughAttribute]
		public string NG1()
		{
			return string.Empty;
		}

		[DebuggerStepThroughAttribute(), System.Diagnostics.DebuggerNonUserCodeAttribute()]
		public string NG2()
		{
			return string.Empty;
		}
	}
}
