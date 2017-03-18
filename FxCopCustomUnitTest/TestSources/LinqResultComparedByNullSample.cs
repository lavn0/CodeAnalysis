using System.Collections.Generic;
using System.Linq;
using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	public static class LinqResultComparedByNullSample
	{
		public static List<string> GetSample()
		{
			return new List<string>() { "1", "2", "3" };
		}

		[TestInfo(TargetRuleName = nameof(LinqResultComparedByNull), ViolationCount = 1)]
		public static bool NG1()
		{
			var sequence = GetSample().Where(e => e is string);
			if (sequence != null)
			{
				return sequence.Any();
			}

			return false;
		}

		[TestInfo(TargetRuleName = nameof(LinqResultComparedByNull), ViolationCount = 1)]
		public static bool NG2()
		{
			var sequence = GetSample().Where(e => e is string);
			if (null != sequence)
			{
				return sequence.Any();
			}

			return false;
		}

		[TestInfo(TargetRuleName = nameof(LinqResultComparedByNull), ViolationCount = 0)]
		public static bool OK1()
		{
			var sequence = GetSample().Where(e => e is string);
			return sequence.Any();
		}
	}
}
