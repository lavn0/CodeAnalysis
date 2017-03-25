using System.Collections.Generic;
using PhoenixCustom;
using TestUtility;

namespace PhoenixCustomUnitTest.TestSoures
{
	public static class AvoidDoubleCastSample
	{
		[TestInfo(TargetRuleName = nameof(AvoidDoubleCast), ViolationCount = 1)]
		public static void NG1(IEnumerable<string> items, string item1, string item2)
		{
			((List<string>)items).Add(item1);
			((List<string>)items).Add(item2);
		}

		[TestInfo(TargetRuleName = nameof(AvoidDoubleCast), ViolationCount = 0)]
		public static object OK1(IEnumerable<string> items, string item)
		{
			if (items is List<string>)
			{
				((List<string>)items).Add(item);
			}

			return null;
		}

		[TestInfo(TargetRuleName = nameof(AvoidDoubleCast), ViolationCount = 0)]
		public static object OK2(IEnumerable<string> items)
		{
			if (items is List<string>)
			{
				return items as List<string>;
			}

			return null;
		}
	}
}
