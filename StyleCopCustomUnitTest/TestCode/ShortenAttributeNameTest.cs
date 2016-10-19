using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class ShortenAttributeNameTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void ShortenAttributeNameTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\ShortenAttributeNameTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "ShortenAttributeName").ToList();
			Assert.AreEqual(3, violations.Count);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(0).Element.GetType().FullName);
			var method0 = result.Violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG1", method0.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(1).Element.GetType().FullName);
			var method1 = result.Violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NG2", method1.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(2).Element.GetType().FullName);
			var method2 = result.Violations.ElementAt(2).Element as Method;
			Assert.AreEqual("NG2", method2.Declaration.Name);
		}
	}
}
