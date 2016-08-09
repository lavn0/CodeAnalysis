using System.Collections.Generic;
using System.Linq;

namespace StyleCopCustomUnitTest.Resources
{
	// Test
	public static class NumberAmoountRuleTestClass
	{
		public int OKField = 1000 * 1000;
		public int NGField = 1000000;

		public void OKNumberLocal()
		{
			int i = 1000 * 1000;
		}

		public void NGNumberLocal()
		{
			int i = 10000000;
		}

		public void OKInitParams(int i = 1000 * 1000)
		{
		}

		public void NGInitParams(int i = 1000000)
		{
		}

		public viod OKExpression()
		{
			var ls = Enumerable.Range(1, 10).Select(i => i * 10 * 1000);
		}

		public viod NGExpression()
		{
			var ls = Enumerable.Range(1, 10).Select(i => i * 10000);
		}
	}
}
