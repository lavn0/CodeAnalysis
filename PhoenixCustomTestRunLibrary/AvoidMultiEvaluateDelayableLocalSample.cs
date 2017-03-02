using System.Collections.Generic;
using System.Linq;

namespace PhoenixCustomTestRunLibrary
{
	public class AvoidMultiEvaluateDelayableLocalSample
	{
		// 1回だけ評価するのはOK
		public static object OK()
		{
			var items = new[] { "test1", "test2", }.Where(s => s.StartsWith("test"));
			return items.ToList();
		}

		// 2回評価するのはNG
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

		// ２つ評価式があっても同じパスで２回評価されていない場合はOK
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