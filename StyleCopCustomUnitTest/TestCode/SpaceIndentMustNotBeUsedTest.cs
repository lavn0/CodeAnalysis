using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class SpaceIndentMustNotBeUsedTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void SpaceIndentMustNotBeUsedTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\SpaceIndentMustNotBeUsedTestClass.cs");
			Assert.AreEqual(5, result.Violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(0).Element.GetType().FullName);
			var method0 = result.Violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG1", method0.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(1).Element.GetType().FullName);
			var method1 = result.Violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NG2", method1.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(2).Element.GetType().FullName);
			var method2 = result.Violations.ElementAt(2).Element as Method;
			Assert.AreEqual("NG2", method2.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(3).Element.GetType().FullName);
			var method3 = result.Violations.ElementAt(3).Element as Method;
			Assert.AreEqual("NG3", method3.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(4).Element.GetType().FullName);
			var method4 = result.Violations.ElementAt(4).Element as Method;
			Assert.AreEqual("NG3", method4.Declaration.Name);
		}
	}
}
