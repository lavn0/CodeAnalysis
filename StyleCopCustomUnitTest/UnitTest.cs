using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class StyleCopUnitTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void AvoidMagicNumberRule()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\AvoidMagicNumberRule.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "AvoidMagicNumberRule").ToList();

			Assert.AreEqual(29, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(48, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(54, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(57, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(58, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[2].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(61, violations[2].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(64, violations[2].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[3].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(67, violations[3].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(71, violations[3].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[4].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(74, violations[4].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(77, violations[4].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[5].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(48, violations[5].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(64, violations[5].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[6].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(67, violations[6].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(78, violations[6].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[7].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(81, violations[7].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(99, violations[7].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[8].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(102, violations[8].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(123, violations[8].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[9].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(126, violations[9].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(145, violations[9].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(10, violations.Count);
		}

		[TestMethod]
		public void NumberAmoountRule()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\NumberAmoountRule.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "NumberAmoountRule").ToList();

			Assert.AreEqual(8, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(24, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(30, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(17, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(12, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(19, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(24, violations[2].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(36, violations[2].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(42, violations[2].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[3].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(53, violations[3].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(57, violations[3].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(4, violations.Count);
		}

		[TestMethod]
		public void PreferAtmarkQuotedString()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\PreferAtmarkQuotedString.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "PreferAtmarkQuotedString").ToList();

			Assert.AreEqual(7, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(33, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(45, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(24, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(23, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(2, violations.Count);
		}

		[TestMethod]
		public void ShortenAttributeEmptyParenthesis()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\ShortenAttributeEmptyParenthesis.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeEmptyParenthesis").ToList();

			Assert.AreEqual(19, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(4, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(24, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(64, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(2, violations.Count);
		}

		[TestMethod]
		public void ShortenAttributeName()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\ShortenAttributeName.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeName").ToList();

			Assert.AreEqual(13, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(4, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(31, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(19, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(4, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(33, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(19, violations[2].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(36, violations[2].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(84, violations[2].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(3, violations.Count);
		}

		[TestMethod]
		public void SpaceAndTabMixedIndentMustNotBeUsed()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\SpaceAndTabMixedIndentMustNotBeUsed.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceAndTabMixedIndentMustNotBeUsed").ToList();

			Assert.AreEqual(12, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(9, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(7, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(26, violations[2].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[2].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(7, violations[2].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(32, violations[3].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[3].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[3].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(33, violations[4].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[4].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[4].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(5, violations.Count);
		}

		[TestMethod]
		public void SpaceIndentMustNotBeUsed()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\SpaceIndentMustNotBeUsed.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceIndentMustNotBeUsed").ToList();

			Assert.AreEqual(12, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(12, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(8, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(26, violations[2].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[2].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(8, violations[2].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(32, violations[3].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[3].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[3].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(33, violations[4].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[4].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[4].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(5, violations.Count);
		}

		[TestMethod]
		public void TabNotBeUseInNonIndent()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\TabNotBeUseInNonIndent.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "TabNotBeUseInNonIndent").ToList();

			Assert.AreEqual(12, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations.Count);
		}

		[TestMethod]
		public void TrailingSpacesMustNotBeUsed()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\TrailingSpacesMustNotBeUsed.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "TrailingSpacesMustNotBeUsed").ToList();

			Assert.AreEqual(30, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(12, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(11, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(40, violations[2].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[2].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(11, violations[2].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(3, violations.Count);
		}

		[TestMethod]
		public void WideSpaceNotBeUsed()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\WideSpaceNotBeUsed.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "WideSpaceNotBeUsed").ToList();

			Assert.AreEqual(10, violations[0].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(9, violations[0].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(9, violations[0].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(12, violations[1].Line, "エラーの開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[1].Location.Value.StartPoint.IndexOnLine, "エラーの開始位置が期待値と異なります。");
			Assert.AreEqual(4, violations[1].Location.Value.EndPoint.IndexOnLine, "エラーの終了位置が期待値と異なります。");
			Assert.AreEqual(2, violations.Count);
		}

		[TestMethod]
		public void XmlCommentRuleTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\XmlCommentRuleTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "XmlCommentRuleTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}
	}
}