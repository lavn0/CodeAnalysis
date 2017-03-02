using System.Collections.Generic;

namespace PhoenixCustomTestRunLibrary
{
	public class EnumerateMethodShouldBeDelayedSample
	{
		// 戻り値を持たない処理は関係ない
		public void OK()
		{
			return;
		}

		// 遅延評価可能なシグネチャをした処理がインスタンスを返却するとNG
		public IEnumerable<string> NG1()
		{
			return new[] { "test1", "test2", };
		}

		public IEnumerable<string> OK1()
		{
			yield return "test1";
			yield return "test2";
		}
	}
}
