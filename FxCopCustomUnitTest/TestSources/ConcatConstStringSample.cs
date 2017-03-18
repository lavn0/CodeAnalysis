using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	/// <summary>固定文字連結をする処理のサンプルコード</summary>
	public static class ConcatConstStringSample
	{
		[TestInfo(TargetRuleName = nameof(ConcatConstString), ViolationCount = 1)]
		public static string NG1()
		{
			// 良くある固定値の連結
			var item = "a";
			item += "b";
			return item;

			/*
			適切な記述は以下
			var a = "a" + "b";
			return a;
			 */
		}

		[TestInfo(TargetRuleName = nameof(ConcatConstString), ViolationCount = 1)]
		public static string NG2()
		{
			// NG1とコンパイル後は全く同じになる処理
			var item = "a";
			item = item + "b";
			return item;
		}

		[TestInfo(TargetRuleName = nameof(ConcatConstString), ViolationCount = 2)]
		public static string NG3()
		{
			// NG2の逆順連結
			var item = "a";
			item += "b" + item;
			return item;
		}

		[TestInfo(TargetRuleName = nameof(ConcatConstString), ViolationCount = 2)]
		public static string NG4()
		{
			// NG3とコンパイル後は全く同じになる処理
			var item = "a";
			item = string.Concat(item, "b", item);
			return item;
		}

		[TestInfo(TargetRuleName = nameof(ConcatConstString), ViolationCount = 3)]
		public static string NG5()
		{
			var item = "a";
			item += "b" + item + "c";
			return item;
		}

		[TestInfo(TargetRuleName = nameof(ConcatConstString), ViolationCount = 0)]
		public static string OK1()
		{
			// この連結はparamsを引き数に取る連結は判定できていない
			var item = "a";
			item += "b" + item + "c" + item;
			return item;
		}
	}
}
