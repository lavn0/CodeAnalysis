using System.Collections.Generic;
using System.Linq;

namespace FxCopCustomTestRunLibrary
{
	public static class CompareZeroToCountResultSample
	{
		public static bool CompareZeroToCountResultOK(IEnumerable<object> source)
		{
			return source.Any();
		}

		public static bool CompareZeroToCountResultNG1(IEnumerable<object> source)
		{
			return source.Count() != 0;
		}

		public static bool CompareZeroToCountResultNG2(IEnumerable<object> source)
		{
			return 0 != source.Count();
		}

		public static bool CompareZeroToCountResultNG3(IEnumerable<object> source)
		{
			return source.Count() > 0;
		}

		public static bool CompareZeroToCountResultNG4(IEnumerable<object> source)
		{
			return 0 < source.Count();
		}

		public static bool CompareZeroToCountResultNG5(IEnumerable<object> source)
		{
			return source.Count() < 1;
		}

		public static bool CompareZeroToCountResultNG6(IEnumerable<object> source)
		{
			return 1 > source.Count();
		}

		public static bool CompareZeroToCountResultNG7(IEnumerable<object> source)
		{
			return source.Count() <= 0;
		}

		public static bool CompareZeroToCountResultNG8(IEnumerable<object> source)
		{
			return 0 >= source.Count();
		}

		public static bool CompareZeroToCountResultNG9(IEnumerable<object> source)
		{
			return source.Count() >= 1;
		}

		public static bool CompareZeroToCountResultNG10(IEnumerable<object> source)
		{
			return 1<= source.Count();
		}
	}
}
