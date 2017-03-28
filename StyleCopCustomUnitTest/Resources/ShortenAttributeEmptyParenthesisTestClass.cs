using System.Diagnostics;

namespace StyleCopCustomUnitTest.Resources
{
	[DebuggerDisplay("hoge, fuga"), DebuggerStepThrough]
	public class ShortenAttributeEmptyParenthesisTestClass
	{
		public string OK1
		{
			get { return string.Empty; }
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
