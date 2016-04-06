namespace FxCopCustomTestRunLibrary
{
	public class DontDefineMemberSample
	{
		public static bool IsFieldOK;
		public static bool IsPropertyOK { get; set; }
		public static bool IsMethodOK() { return true; }
		public static void AddOK() { }
		public static void PutOK() { }
		public static void RemoveOK() { }

		public static string IsFieldNG = "true";
		public static string IsPropertyNG { get; set; } = "true";
		public static string IsMethodNG() { return "true"; }


		public static string CanFieldNG = "true";
		public static string HasFieldNG = "true";
		public static string ShouldFieldNG = "true";
		public static string CouldFieldNG = "true";
		public static string WillFieldNG = "true";
		public static string ShallFieldNG = "true";
		public static string CheckFieldNG = "true";
		public static string ContainsFieldNG = "true";
		public static string EqualsFieldNG = "true";
		public static string StartsWithNG() { return "true"; }
		public static string EndsWith() { return "true"; }
	}
}
