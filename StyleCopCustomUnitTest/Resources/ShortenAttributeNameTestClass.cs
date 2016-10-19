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
		public string NG()
		{
			return string.Empty;
		}
	}
}
