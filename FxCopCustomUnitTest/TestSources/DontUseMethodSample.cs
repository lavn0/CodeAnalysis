using System.Collections.Generic;
using System.Linq;
using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	public static class DontUseMethodSample
	{
		private static void DontUseMethodCall()
		{
		}

		[TestInfo(TargetRuleName = nameof(DontUseMethod), ViolationCount = 0)]
		public static void OK()
		{
			new List<string>().ToList();
		}

		[TestInfo(TargetRuleName = nameof(DontUseMethod), ViolationCount = 1)]
		public static void NG1()
		{
			DontUseMethodCall();
		}
	}
}
