using System.Linq;

namespace PhoenixCustomTestRunLibrary
{
	public static class AvoidNonNullMethodResultComparedByNullSample
	{
		// 比較していない場合はOK
		public static object OK1()
		{
			var test = new[] { "a", "b", }.Where(s => s.StartsWith("a"));
			if (test.Any())
			{
				return test;
			}

			return null;
		}

		// null以外と比較している場合はOK
		public static object OK2()
		{
			var test = new[] { "a", "b", }.Where(s => s.StartsWith("a"));
			if (test == new object())
			{
				return null;
			}

			return test;
		}

		// 一部のパスでインスタンスがある場合は、OK
		public static bool OK3(bool flg)
		{
			var sequence = new[] { "1", "2", "3", }.Where(e => e is string);
			if (flg)
			{
				sequence = new[] { "1", "2", "3", }.ToList();
			}

			if (sequence != null)
			{
				return sequence.Any();
			}

			return false;
		}

		// LINQのWhereメソッドの結果はnullと比較すると NG
		public static object NG1()
		{
			var test = new[] { "a", "b", }.Where(s => s.StartsWith("a"));
			if (test != null)
			{
				return test;
			}

			return null;
		}

		// nullとの比較が逆でも NG
		public static object NG2()
		{
			var test = new[] { "a", "b", }.Where(s => s.StartsWith("a"));
			if (null != test)
			{
				return test;
			}

			return null;
		}

		// ネストに囲まれた外側で代入、内側で比較していた場合も NGとして検出する
		public static object NG3(bool flg)
		{
			var test = new[] { "a", "b", }.Where(s => s.StartsWith("a"));
			if (flg)
			{
				if (test != null)
				{
					return test;
				}
			}
			else
			{
				if (test != null)
				{
					return test;
				}
			}

			return null;
		}
	}
}
