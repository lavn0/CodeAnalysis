using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomUnitTest
{
	public static class AsignedConstOnlySample
	{
		[TestInfo(TargetRuleName = nameof(AsignedConstOnly), ViolationCount = 1)]
		public static string NG1()
		{
			var local = "a";
			return local;
		}

		[TestInfo(TargetRuleName = nameof(AsignedConstOnly), ViolationCount = 1)]
		public static string NG2()
		{
			var local = "a";
			local = "b";
			return local;
		}

		[TestInfo(TargetRuleName = nameof(AsignedConstOnly), ViolationCount = 1)]
		public static int NG3()
		{
			var local = 0;
			local = 1;
			return local;
		}

		[TestInfo(TargetRuleName = nameof(AsignedConstOnly), ViolationCount = 0)]
		public static string OK1()
		{
			const string local = "a";
			return local;
		}

		[TestInfo(TargetRuleName = nameof(AsignedConstOnly), ViolationCount = 0)]
		public static string OK2()
		{
			var local = "a";
			local += "b";
			return local;
		}

		[TestInfo(TargetRuleName = nameof(AsignedConstOnly), ViolationCount = 0)]
		public static int OK3()
		{
			var local = 0;
			local++;
			return local;
		}
	}
}
