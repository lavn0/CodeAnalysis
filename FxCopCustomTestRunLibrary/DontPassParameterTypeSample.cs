using System.Collections.Generic;
using System.Linq;

namespace FxCopCustomTestRunLibrary
{
	public static class DontPassParameterTypeSample
	{
		public static void Sample1(IEnumerable<string> ls1, IEnumerable<string> ls2, IEnumerable<string> ls3) { }

		public static void OK1()
		{
			var ls1 = new List<string>() { "hoge", "fuga", }.Where(s => s.StartsWith("a"));
			var ls2 = new List<string>() { "hoge", "fuga", };
			var ls3 = new List<string>() { "hoge", "fuga", }.Where(s => s.StartsWith("a"));
			Sample1(ls1, ls2, ls3);
		}

		public static void NG1()
		{
			var ls1 = new List<string>() { "hoge", "fuga", };
			var ls2 = new List<string>() { "hoge", "fuga", }.Where(s => s.StartsWith("a"));
			var ls3 = new List<string>() { "hoge", "fuga", };
			Sample1(ls1, ls2, ls3);
		}
	}
}
