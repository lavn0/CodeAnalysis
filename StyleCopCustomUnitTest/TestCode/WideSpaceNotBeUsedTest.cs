using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class WideSpaceNotBeUsedTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void WideSpaceNotBeUsedTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\WideSpaceNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "WideSpaceNotBeUsed").ToList();
			Assert.AreEqual(2, violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(0).Element.GetType().FullName);
			var method0 = violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG1", method0.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(1).Element.GetType().FullName);
			var method1 = violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NG1", method1.Declaration.Name);
		}
	}
}
