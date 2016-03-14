namespace FxCopCustomTestRunLibrary
{
	public static class AsignedConstOnlySample
	{
		public static string AsignedConstOnlySample_NG1()
		{
			var local = "a";
			return local;
		}

		public static string AsignedConstOnlySample_NG2()
		{
			var local = "a";
			local = "b";
			return local;
		}

		public static int AsignedConstOnlySample_NG3()
		{
			var local = 0;
			local = 1;
			return local;
		}

		public static string AsignedConstOnlySample_OK1()
		{
			const string local = "a";
			return local;
		}

		public static string AsignedConstOnlySample_OK2()
		{
			var local = "a";
			local += "b";
			return local;
		}

		public static int AsignedConstOnlySample_OK3()
		{
			var local = 0;
			local++;
			return local;
		}
	}
}
