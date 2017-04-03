using System.Linq;

namespace StyleCopCustomUnitTest.TestSources
{
	public class NumberAmoountRule
	{
		public int OKField = 1000 * 1000;
		// ERROR(24,30) NGField
		public int NGField = 1000000;

		public void OKNumberLocal()
		{
			int i = 1000 * 1000;
		}

		public void NGNumberLocal()
		{
			// ERROR(12,19) i
			int i = 10000000;
		}

		public void OKInitParams(int i = 1000 * 1000)
		{
		}

		// ERROR(36,42) i
		public void NGInitParams(int i = 1000000)
		{
		}

		public void OKExpression()
		{
			var ls = Enumerable.Range(1, 10).Select(i => i * 10 * 1000);
		}

		public void NGExpression()
		{
			// ERROR(53,57) i
			var ls = Enumerable.Range(1, 10).Select(i => i * 10000);
		}
	}
}
