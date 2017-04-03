using System.IO;
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
			var path = @"TestSources\AvoidMagicNumberRule.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "AvoidMagicNumberRule").ToList();

			Assert.AreEqual(29, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(39, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(45, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(48, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(49, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(52, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(55, violations[2].Location.Value.EndPoint.IndexOnLine, "エラー[2]の終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[3].Line, "エラー[3]の開始行が期待値と異なります。");
			Assert.AreEqual(58, violations[3].Location.Value.StartPoint.IndexOnLine, "エラー[3]の開始位置が期待値と異なります。");
			Assert.AreEqual(62, violations[3].Location.Value.EndPoint.IndexOnLine, "エラー[3]の終了位置が期待値と異なります。");
			Assert.AreEqual(29, violations[4].Line, "エラー[4]の開始行が期待値と異なります。");
			Assert.AreEqual(65, violations[4].Location.Value.StartPoint.IndexOnLine, "エラー[4]の開始位置が期待値と異なります。");
			Assert.AreEqual(68, violations[4].Location.Value.EndPoint.IndexOnLine, "エラー[4]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[5].Line, "エラー[5]の開始行が期待値と異なります。");
			Assert.AreEqual(39, violations[5].Location.Value.StartPoint.IndexOnLine, "エラー[5]の開始位置が期待値と異なります。");
			Assert.AreEqual(55, violations[5].Location.Value.EndPoint.IndexOnLine, "エラー[5]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[6].Line, "エラー[6]の開始行が期待値と異なります。");
			Assert.AreEqual(58, violations[6].Location.Value.StartPoint.IndexOnLine, "エラー[6]の開始位置が期待値と異なります。");
			Assert.AreEqual(69, violations[6].Location.Value.EndPoint.IndexOnLine, "エラー[6]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[7].Line, "エラー[7]の開始行が期待値と異なります。");
			Assert.AreEqual(72, violations[7].Location.Value.StartPoint.IndexOnLine, "エラー[7]の開始位置が期待値と異なります。");
			Assert.AreEqual(90, violations[7].Location.Value.EndPoint.IndexOnLine, "エラー[7]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[8].Line, "エラー[8]の開始行が期待値と異なります。");
			Assert.AreEqual(93, violations[8].Location.Value.StartPoint.IndexOnLine, "エラー[8]の開始位置が期待値と異なります。");
			Assert.AreEqual(114, violations[8].Location.Value.EndPoint.IndexOnLine, "エラー[8]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[9].Line, "エラー[9]の開始行が期待値と異なります。");
			Assert.AreEqual(117, violations[9].Location.Value.StartPoint.IndexOnLine, "エラー[9]の開始位置が期待値と異なります。");
			Assert.AreEqual(136, violations[9].Location.Value.EndPoint.IndexOnLine, "エラー[9]の終了位置が期待値と異なります。");
			Assert.AreEqual(10, violations.Count);
		}

		[TestMethod]
		public void NumberAmoountRule()
		{
			var path = @"TestSources\NumberAmoountRule.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "NumberAmoountRule").ToList();

			Assert.AreEqual(8, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(24, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(30, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(17, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(12, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(19, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(24, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(36, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(42, violations[2].Location.Value.EndPoint.IndexOnLine, "エラー[2]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[3].Line, "エラー[3]の開始行が期待値と異なります。");
			Assert.AreEqual(53, violations[3].Location.Value.StartPoint.IndexOnLine, "エラー[3]の開始位置が期待値と異なります。");
			Assert.AreEqual(57, violations[3].Location.Value.EndPoint.IndexOnLine, "エラー[3]の終了位置が期待値と異なります。");
			Assert.AreEqual(4, violations.Count);
		}

		[TestMethod]
		public void PreferAtmarkQuotedString()
		{
			var path = @"TestSources\PreferAtmarkQuotedString.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "PreferAtmarkQuotedString").ToList();

			Assert.AreEqual(7, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(33, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(45, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(24, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(23, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(2, violations.Count);
		}

		[TestMethod]
		public void ShortenAttributeEmptyParenthesis()
		{
			var path = @"TestSources\ShortenAttributeEmptyParenthesis.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeEmptyParenthesis").ToList();

			Assert.AreEqual(19, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(4, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(24, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(64, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(2, violations.Count);
		}

		[TestMethod]
		public void ShortenAttributeName()
		{
			var path = @"TestSources\ShortenAttributeName.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeName").ToList();

			Assert.AreEqual(13, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(4, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(31, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(19, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(4, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(33, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(19, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(36, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(84, violations[2].Location.Value.EndPoint.IndexOnLine, "エラー[2]の終了位置が期待値と異なります。");
			Assert.AreEqual(3, violations.Count);
		}

		[TestMethod]
		public void SpaceAndTabMixedIndentMustNotBeUsed()
		{
			var path = @"TestSources\SpaceAndTabMixedIndentMustNotBeUsed.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceAndTabMixedIndentMustNotBeUsed").ToList();

			Assert.AreEqual(12, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(9, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(7, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(26, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(7, violations[2].Location.Value.EndPoint.IndexOnLine, "エラー[2]の終了位置が期待値と異なります。");
			Assert.AreEqual(32, violations[3].Line, "エラー[3]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[3].Location.Value.StartPoint.IndexOnLine, "エラー[3]の開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[3].Location.Value.EndPoint.IndexOnLine, "エラー[3]の終了位置が期待値と異なります。");
			Assert.AreEqual(33, violations[4].Line, "エラー[4]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[4].Location.Value.StartPoint.IndexOnLine, "エラー[4]の開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[4].Location.Value.EndPoint.IndexOnLine, "エラー[4]の終了位置が期待値と異なります。");
			Assert.AreEqual(5, violations.Count);
		}

		[TestMethod]
		public void SpaceIndentMustNotBeUsed()
		{
			var path = @"TestSources\SpaceIndentMustNotBeUsed.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceIndentMustNotBeUsed").ToList();

			Assert.AreEqual(12, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(12, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(25, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(8, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(26, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(8, violations[2].Location.Value.EndPoint.IndexOnLine, "エラー[2]の終了位置が期待値と異なります。");
			Assert.AreEqual(32, violations[3].Line, "エラー[3]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[3].Location.Value.StartPoint.IndexOnLine, "エラー[3]の開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[3].Location.Value.EndPoint.IndexOnLine, "エラー[3]の終了位置が期待値と異なります。");
			Assert.AreEqual(33, violations[4].Line, "エラー[4]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[4].Location.Value.StartPoint.IndexOnLine, "エラー[4]の開始位置が期待値と異なります。");
			Assert.AreEqual(6, violations[4].Location.Value.EndPoint.IndexOnLine, "エラー[4]の終了位置が期待値と異なります。");
			Assert.AreEqual(5, violations.Count);
		}

		[TestMethod]
		public void TabNotBeUseInNonIndent()
		{
			var path = @"TestSources\TabNotBeUseInNonIndent.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "TabNotBeUseInNonIndent").ToList();

			Assert.AreEqual(12, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations.Count);
		}

		[TestMethod]
		public void TrailingSpacesMustNotBeUsed()
		{
			var path = @"TestSources\TrailingSpacesMustNotBeUsed.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "TrailingSpacesMustNotBeUsed").ToList();

			Assert.AreEqual(30, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(12, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(35, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(11, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(40, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(11, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(11, violations[2].Location.Value.EndPoint.IndexOnLine, "エラー[2]の終了位置が期待値と異なります。");
			Assert.AreEqual(3, violations.Count);
		}

		[TestMethod]
		public void WideSpaceNotBeUsed()
		{
			var path = @"TestSources\WideSpaceNotBeUsed.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "WideSpaceNotBeUsed").ToList();

			Assert.AreEqual(10, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(9, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(9, violations[0].Location.Value.EndPoint.IndexOnLine, "エラー[0]の終了位置が期待値と異なります。");
			Assert.AreEqual(12, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(1, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(4, violations[1].Location.Value.EndPoint.IndexOnLine, "エラー[1]の終了位置が期待値と異なります。");
			Assert.AreEqual(2, violations.Count);
		}

		[TestMethod]
		public void XmlCommentRule()
		{
			var path = @"TestSources\XmlCommentRule.cs";
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path + " が見つかりません。");
			}

			var result = StyleCopUtil.RunStyleCop(settingPath, path);
			var violations = result.Violations.Where(v => v.Rule.Name == "XmlCommentRule").ToList();

			Assert.AreEqual(21, violations[0].Line, "エラー[0]の開始行が期待値と異なります。");
			Assert.AreEqual(3, violations[0].Location.Value.StartPoint.IndexOnLine, "エラー[0]の開始位置が期待値と異なります。");
			Assert.AreEqual(26, violations[1].Line, "エラー[1]の開始行が期待値と異なります。");
			Assert.AreEqual(3, violations[1].Location.Value.StartPoint.IndexOnLine, "エラー[1]の開始位置が期待値と異なります。");
			Assert.AreEqual(31, violations[2].Line, "エラー[2]の開始行が期待値と異なります。");
			Assert.AreEqual(3, violations[2].Location.Value.StartPoint.IndexOnLine, "エラー[2]の開始位置が期待値と異なります。");
			Assert.AreEqual(3, violations.Count);
		}
	}
}