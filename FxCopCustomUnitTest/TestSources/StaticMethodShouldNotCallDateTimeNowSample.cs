using System;
using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	public class StaticMethodShouldNotCallDateTimeNowSample
	{
		[TestInfo(TargetRuleName = nameof(StaticMethodShouldNotCallDateTimeNow), ViolationCount = 0)]
		public void OK()
		{
			Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
		}

		[TestInfo(TargetRuleName = nameof(StaticMethodShouldNotCallDateTimeNow), ViolationCount = 1)]
		public static void NG()
		{
			Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
		}
	}
}
