using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
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

			Assert.AreEqual(29, violations[0].Line);
			Assert.AreEqual(29, violations[1].Line);
			Assert.AreEqual(29, violations[2].Line);
			Assert.AreEqual(29, violations[3].Line);
			Assert.AreEqual(29, violations[4].Line);
			Assert.AreEqual(35, violations[5].Line);
			Assert.AreEqual(35, violations[6].Line);
			Assert.AreEqual(35, violations[7].Line);
			Assert.AreEqual(35, violations[8].Line);
			Assert.AreEqual(35, violations[9].Line);
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