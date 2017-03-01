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

		// 変数に結果をキャッシュすれば２回評価されないのでOK
		public static object OK1(IEnumerable<string> items)
		{
			var item = items.FirstOrDefault();
			if (item != null)
			{
				return item;
			}

			return null;
		}

		// ２つ評価式があっても同じパスで２回評価されていない場合はOK
		public static object OK2(IEnumerable<string> items, bool flg)
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

		// ループ内の再評価は未判定
		public static object OK3(IEnumerable<string> items)
		{
			var ls = new List<string>();
			foreach (var item in items)
			{
				ls.Add(items.FirstOrDefault());
			}

			return ls;
		}
	}
}