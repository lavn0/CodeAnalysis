using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class TrailingSpacesMustNotBeUsedTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void TrailingSpacesMustNotBeUsedTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\TrailingSpacesMustNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "TrailingSpacesMustNotBeUsed").ToList();
			Assert.AreEqual(3, violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(0).Element.GetType().FullName);
			var method0 = violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG1", method0.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(1).Element.GetType().FullName);
			var method1 = violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NG2", method1.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(2).Element.GetType().FullName);
			var method2 = violations.ElementAt(2).Element as Method;
			Assert.AreEqual("NG3", method2.Declaration.Name);
		}
	}
}
