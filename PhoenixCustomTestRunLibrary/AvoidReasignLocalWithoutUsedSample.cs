using System.Collections.Generic;
using System.Linq;
using PhoenixCustom;
using TestUtility;

namespace PhoenixCustomTestRunLibrary
{
	public static class AvoidReasignLocalWithoutUsedSample
	{
		// 戻り値に使われている
		[TestInfo(TargetRuleName = nameof(AvoidReasignLocalWithoutUsed), ViolationCount = 0)]
		public static object OK1()
		{
			var ls = new List<string>();
			return ls;
		}

		// 複数のパスで破棄されるとは限らない場合
		[TestInfo(TargetRuleName = nameof(AvoidReasignLocalWithoutUsed), ViolationCount = 0)]
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
		[TestInfo(TargetRuleName = nameof(AvoidReasignLocalWithoutUsed), ViolationCount = 1)]
		public static object NG1()
		{
			var ls = new List<string>(); // このインスタンスが使われずに必ず破棄されるのでNG
			ls = GetData();
			return ls;
		}

		// 再代入され、使用されなかった変数(2度目)もNG
		[TestInfo(TargetRuleName = nameof(AvoidReasignLocalWithoutUsed), ViolationCount = 2)]
		public static object NG2()
		{
			var ls = new List<string>(); // このインスタンスが使われずに必ず破棄されるのでNG
			ls = GetData(); // このインスタンスが使われずに必ず破棄されるのでNG
			ls = new List<string>();
			return ls;
		}

		// 複数のパスで必ず破棄される
		[TestInfo(TargetRuleName = nameof(AvoidReasignLocalWithoutUsed), ViolationCount = 1)]
		public static object NG3(bool flg)
		{
			var ls = new List<string>(); // このインスタンスが使われずに必ず破棄されるのでNG
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