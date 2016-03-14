namespace FxCopCustomTestRunLibrary
{
	public static class AsignedConstOnlyTest
	{
		public static string NG1()
		{
			var local = "a";
			return local;
		}

		public static string NG2()
		{
			var local = "a";
			local = "b";
			return local;
		}

		public static int NG3()
		{
			var local = 0;
			local = 1;
			return local;
		}

		public static string OK1()
		{
			const string local = "a";
			return local;
		}

		public static string OK2()
		{
			var local = "a";
			local += "b";
			return local;
		}

		public static int OK3()
		{
			var local = 0;
			local++;
			return local;
		}
	}
}
