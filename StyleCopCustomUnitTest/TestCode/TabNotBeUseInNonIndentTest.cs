using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class TabNotBeUseInNonIndentTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void TabNotBeUseInNonIndentTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\TabNotBeUseInNonIndentTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "TabNotBeUseInNonIndent").ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(0).Element.GetType().FullName);
			var method0 = violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG", method0.Declaration.Name);
		}
	}
}
