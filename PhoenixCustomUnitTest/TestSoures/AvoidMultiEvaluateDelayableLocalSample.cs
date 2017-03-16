using System.Collections.Generic;
using System.Linq;
using PhoenixCustom;
using TestUtility;

namespace PhoenixCustomUnitTest
{
	public class AvoidMultiEvaluateDelayableLocalSample
	{
		// 1回だけ評価するのはOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 0)]
		public static object OK()
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test"));
			return items.ToList();
		}

		// 2回評価するのはNG
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 1)]
		public static object NG1()
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test"));
			if (items.Any())
			{
				return items.ToList();
			}

			return null;
		}

		// 変数に結果をキャッシュすれば２回評価されないのでOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 0)]
		public static object OK1()
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test"));
			var item = items.FirstOrDefault();
			if (item != null)
			{
				return item;
			}

			return null;
		}

		// 引き数を2回評価するのはOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 0)]
		public static object OK1_2(IEnumerable<string> items)
		{
			if (items.Any())
			{
				return items.ToList();
			}

			return null;
		}

		// ２つ評価式があっても同じパスで２回評価されていない場合はOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 0)]
		public static object OK2(bool flg)
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test"));
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
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 0)]
		public static object NG3()
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test"));
			var ls = new List<string>();
			for (var i = 0; i < 10; i++)
			{
				ls.Add(items.FirstOrDefault());
			}

			return ls;
		}

		// 遅延評価されない型
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluateDelayableLocal), ViolationCount = 0)]
		public static object OK4()
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test")).ToList();
			if (items.Any())
			{
				return items.ToList();
			}

			return null;
		}
	}
}