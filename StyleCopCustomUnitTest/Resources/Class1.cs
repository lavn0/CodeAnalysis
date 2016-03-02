using System.Collections.Generic;
using System.Linq;

namespace StyleCopCustomUnitTest.Resources
{
	public static class Class1
	{
		public static IEnumerable<string> GetDatas()
		{
			return new List<string>() { "a", "b", "c" }.OrderBy(a => a).OrderBy(a => a);
		}
	}
}
