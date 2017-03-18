using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	public class DontDefineMemberSample
	{
		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 0)]
		public static bool IsFieldOK;

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 0)]
		public static bool IsPropertyOK { get; set; }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 0)]
		public static bool IsMethodOK() { return true; }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 0)]
		public static void AddOK() { }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 0)]
		public static void PutOK() { }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 0)]
		public static void RemoveOK() { }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string IsFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string IsPropertyNG { get; set; } = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string IsMethodNG() { return "true"; }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string CanFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string HasFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string ShouldFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string CouldFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string WillFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string ShallFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string CheckFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string ContainsFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string EqualsFieldNG = "true";

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string StartsWithNG() { return "true"; }

		[TestInfo(TargetRuleName = nameof(DontDefineMember), ViolationCount = 1)]
		public static string EndsWith() { return "true"; }
	}
}
