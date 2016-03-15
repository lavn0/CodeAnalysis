namespace FxCopCustomTestRunLibrary
{
	/// <summary>固定文字連結をする処理のサンプルコード</summary>
	public static class ConcatConstStringSample
	{
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

		public static string NG2()
		{
			// NG1とコンパイル後は全く同じになる処理
			var item = "a";
			item = item + "b";
			return item;
		}

		public static string NG3()
		{
			// NG2の逆順連結
			var item = "a";
			item += "b" + item;
			return item;
		}

		public static string NG4()
		{
			// NG3とコンパイル後は全く同じになる処理
			var item = "a";
			item = string.Concat(item, "b", item);
			return item;
		}

		public static string NG5()
		{
			var item = "a";
			item += "b" + item + "c";
			return item;
		}

		public static string OK1()
		{
			// この連結はparamsを引き数に取る連結は判定できていない
			var item = "a";
			item += "b" + item + "c" + item;
			return item;
		}
	}
}
