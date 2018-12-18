using System.Collections.Generic;
using PhoenixCustom.Rules;
using TestUtility;

namespace PhoenixCustomUnitTest.TestSources
{
	public class AvoidMultiGetPropertySample
	{
		// 1回だけ評価するのはOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiGetProperty), ViolationCount = 0)]
		public object OK1()
		{
			return this.Property.IndexOf("a");
		}

		// 2回評価するのはNG
		[TestInfo(TargetRuleName = nameof(AvoidMultiGetProperty), ViolationCount = 1)]
		public object NG1()
		{
			if (this.Property.Contains("a"))
			{
				return this.Property.IndexOf("a");
			}

			return null;
		}

		// メソッドを2回評価するのはOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiGetProperty), ViolationCount = 0)]
		public object OK2()
		{
			if (this.GetProperty().Contains("a"))
			{
				return this.GetProperty().IndexOf("a");
			}

			return null;
		}

		// 変数に結果をキャッシュすれば２回評価されないのでOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiGetProperty), ViolationCount = 0)]
		public object OK3()
		{
			var prop = this.Property;
			if (prop.Contains("a"))
			{
				return prop.IndexOf("a");
			}

			return null;
		}

		// ２つ評価式があっても同じパスで２回評価されていない場合はOK
		[TestInfo(TargetRuleName = nameof(AvoidMultiGetProperty), ViolationCount = 0)]
		public object OK4(bool flg)
		{
			if (flg)
			{
				return this.Property.IndexOf("a");
			}
			else
			{
				return this.Property.IndexOf("b");
			}
		}

		// ループ内の再評価は未判定
		[TestInfo(TargetRuleName = nameof(AvoidMultiGetProperty), ViolationCount = 0)]
		public object NG3()
		{
			var ls = new List<int>();
			for (var i = 0; i < 10; i++)
			{
				ls.Add(this.Property.IndexOf("a"));
			}

			return ls;
		}

		public string Property { get; set; }
		public string GetProperty() => Property;
	}
}