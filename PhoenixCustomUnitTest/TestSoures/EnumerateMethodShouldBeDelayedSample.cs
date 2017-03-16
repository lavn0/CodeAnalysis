using System.Collections.Generic;
using System.Linq;
using PhoenixCustom;
using TestUtility;

namespace PhoenixCustomUnitTest
{
	public class EnumerateMethodShouldBeDelayedSample
	{
		// 戻り値を持たない処理は関係ない
		[TestInfo(TargetRuleName = nameof(EnumerateMethodShouldBeDelayed), ViolationCount = 0)]
		public void OK()
		{
			return;
		}

		// 遅延評価可能なシグネチャをした処理がインスタンスを返却するとNG
		// 実体が遅延評価しないなら、IEnumerable型であるべきではない。
		[TestInfo(TargetRuleName = nameof(EnumerateMethodShouldBeDelayed), ViolationCount = 1)]
		public IEnumerable<string> NG1()
		{
			return new[] { "test1", "test2", };
		}

		[TestInfo(TargetRuleName = nameof(EnumerateMethodShouldBeDelayed), ViolationCount = 0)]
		public IEnumerable<string> OK1()
		{
			yield return "test1";
			yield return "test2";
		}

		[TestInfo(TargetRuleName = nameof(EnumerateMethodShouldBeDelayed), ViolationCount = 0)]
		public IEnumerable<string> OK2()
		{
			return new[] { "test1", "test2", }.Where(s => true);
		}
	}
}
