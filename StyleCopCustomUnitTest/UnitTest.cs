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
		public void NumberAmoountRuleTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\NumberAmoountRuleTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "NumberAmoountRuleTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void PreferAtmarkQuotedStringTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\PreferAtmarkQuotedStringTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "PreferAtmarkQuotedStringTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void ShortenAttributeEmptyParenthesisTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\ShortenAttributeEmptyParenthesisTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeEmptyParenthesisTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void ShortenAttributeNameTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\ShortenAttributeNameTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeNameTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void SpaceAndTabMixedIndentMustNotBeUsedTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\SpaceAndTabMixedIndentMustNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceAndTabMixedIndentMustNotBeUsedTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void SpaceIndentMustNotBeUsedTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\SpaceIndentMustNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceIndentMustNotBeUsedTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void TabNotBeUseInNonIndentTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\TabNotBeUseInNonIndentTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "TabNotBeUseInNonIndentTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void TrailingSpacesMustNotBeUsedTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\TrailingSpacesMustNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "TrailingSpacesMustNotBeUsedTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[TestMethod]
		public void WideSpaceNotBeUsedTestClass()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\WideSpaceNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "WideSpaceNotBeUsedTestClass").ToList();

			Assert.AreEqual(0, violations.Count);
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