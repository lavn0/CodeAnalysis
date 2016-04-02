using System.Collections.Generic;
using System.Linq;

namespace PhoenixCustomTestRunLibrary
{
	public static class AvoidReasignLocalSample
	{
		// 戻り値に使われている
		public static object OK1()
		{
			var ls = new List<string>();
			return ls;
		}

		// 複数のパスで破棄されるとは限らない場合
		public static object OK2(bool flg)
		{
			var ls = new List<string>();
			if (flg)
			{
				ls = GetData().Where(s => s != null).ToList();
			}

			return ls;
		}

		// 再代入され、使用されなかった変数はNG
		public static object NG1()
		{
			var ls = new List<string>();
			ls = GetData();
			return ls;
		}

		// 再代入され、使用されなかった変数(2度目)もNG
		public static object NG2()
		{
			var ls = new List<string>();
			ls = GetData();
			ls = new List<string>();
			return ls;
		}

		// 複数のパスで必ず破棄される
		public static object NG3(bool flg)
		{
			var ls = new List<string>();
			if (flg)
			{
				ls = GetData().Where(s => s != null).ToList();
			}
			else
			{
				ls = GetData();
			}

			return ls;
		}

		private static List<string> GetData()
		{
			return new List<string> { "a", "b", };
		}
	}
}