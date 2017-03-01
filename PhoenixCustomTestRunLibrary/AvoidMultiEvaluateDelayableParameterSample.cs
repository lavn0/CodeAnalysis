using System.Collections.Generic;
using System.Linq;

namespace PhoenixCustomTestRunLibrary
{
	public static class AvoidMultiEvaluateDelayableParameterSample
	{
		// 1回だけ評価するのはOK
		public static object OK(IEnumerable<string> items)
		{
			return items.ToList();
		}

		// 2回評価するのはNG
		public static object NG1(IEnumerable<string> items)
		{
			if (items.Any())
			{
				return items.ToList();
			}

			return null;
		}

		public static object OK1(IEnumerable<string> items)
		{
			var item = items.FirstOrDefault();
			if (item != null)
			{
				return item;
			}

			return null;
		}

		// パス解析は出来ていないのでメソッド内で２回評価していると無条件でエラー
		public static object NG2(IEnumerable<string> items, bool flg)
		{
			if (flg)
			{
				return items.ToList();
			}
			else
			{
				return items.ToArray();
			}
		}
	}
}