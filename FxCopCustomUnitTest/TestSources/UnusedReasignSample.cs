using System.Collections.Generic;
using System.Linq;
using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	public static class UnusedReasignSample
	{
		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 1)]
		public static object NG1()
		{
			var ls = new List<string>();
			ls = GetList1();
			return ls;
		}

		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 1)]
		public static object NG2()
		{
			var ls = GetList1();
			ls = GetList2();
			return ls;
		}

		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 1)]
		public static object NG3()
		{
			var ls = new List<string>();
			ls = GetList3(ls);
			ls = GetList2();
			return ls;
		}

		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 1)]
		public static object NG4()
		{
			List<string> ls;
			ls = new List<string>();
			ls = GetList2();
			return ls;
		}

		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 0)]
		public static object OK1()
		{
			List<string> ls;
			ls = new List<string>();
			return ls;
		}

		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 0)]
		public static object OK2()
		{
			var ls = new List<string>();
			ls = ls.ToList();
			return ls;
		}

		[TestInfo(TargetRuleName = nameof(UnusedReasign), ViolationCount = 0)]
		public static object OK3()
		{
			var ls = new List<string>();
			ls = GetList3(ls);
			return ls;
		}

		private static List<string> GetList1()
		{
			return new List<string>();
		}

		private static List<string> GetList2()
		{
			return new List<string>() { "1", "2", "3" };
		}

		private static List<string> GetList3(List<string> ls)
		{
			return ls.Concat(new[] { "1", "2", "3" }).ToList();
		}
	}
}
