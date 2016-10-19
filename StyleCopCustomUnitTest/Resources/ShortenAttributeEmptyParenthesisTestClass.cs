using System.Diagnostics;

namespace StyleCopCustomUnitTest.Resources
{
	public class ShortenAttributeEmptyParenthesisTestClass
	{
		[DebuggerDisplay("hoge, fuga"), DebuggerStepThrough]
		public string OK1()
		{
			return string.Empty;
		}

		[DebuggerStepThrough]
		public string OK2()
		{
			return string.Empty;
		}

		[DebuggerStepThrough()]
		public string NG1()
		{
			return string.Empty;
		}

		[DebuggerStepThrough, System.Diagnostics.DebuggerNonUserCode()]
		public string NG2()
		{
			return string.Empty;
		}
	}
}
