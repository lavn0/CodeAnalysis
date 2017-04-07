using System.Collections.Generic;
using System.Linq;
using PhoenixCustom.Rules;
using TestUtility;

namespace PhoenixCustomUnitTest.TestSources
{
	public class AvoidMultiCalculatePureMethodSample
	{
		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 0)]
		public void OK1()
		{
			var a = List;
			var b = List;
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 1)]
		public void NG1()
		{
			var a = GetList();
			var b = GetList();
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 1)]
		public void NG2()
		{
			var a = GetList().ToList();
			var b = GetList().ToList();
		}

		private List<string> GetList()
		{
			return new[] { "a", "b", "c" }.ToList();
		}

		private List<string> List
		{
			get { return new[] { "a", "b", "c" }.ToList(); }
		}
	}
}
