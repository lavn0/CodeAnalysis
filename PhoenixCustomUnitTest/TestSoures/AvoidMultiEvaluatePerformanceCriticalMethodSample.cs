using System.Collections.Generic;
using System.Linq;
using PhoenixCustom.Rules;
using TestUtility;

namespace PhoenixCustomUnitTest
{
	public class AvoidMultiEvaluatePerformanceCliticalMethodSample
	{
		// 1回だけ評価するのはOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluatePerformanceCriticalMethod), ViolationCount = 0)]
		public static object OK()
		{
			return GetSample(5).ToList();
		}

		// 2回評価するのはNG
		[TestInfo(TargetRuleName = nameof(AvoidMultiEvaluatePerformanceCriticalMethod), ViolationCount = 1)]
		public static object NG1()
		{
			if (GetSample(5).Any())
			{
				return GetSample(5).ToList();
			}

			return null;
		}

		public static List<int> GetSample(int i)
		{
			return Enumerable.Range(1, i).ToList();
		}
	}
}
