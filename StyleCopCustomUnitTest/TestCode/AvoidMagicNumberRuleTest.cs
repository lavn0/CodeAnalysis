using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class AvoidMagicNumberRuleTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void AvoidMagicNumberRuleTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\AvoidMagicNumberRuleTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "AvoidMagicNumberRule").ToList();

			Assert.AreEqual(10, violations.Count);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(0).Element.GetType().FullName);
			var method0 = violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG1", method0.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(1).Element.GetType().FullName);
			var method1 = violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NG1", method1.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(2).Element.GetType().FullName);
			var method2 = violations.ElementAt(2).Element as Method;
			Assert.AreEqual("NG1", method2.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(3).Element.GetType().FullName);
			var method3 = violations.ElementAt(3).Element as Method;
			Assert.AreEqual("NG1", method3.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(4).Element.GetType().FullName);
			var method4 = violations.ElementAt(4).Element as Method;
			Assert.AreEqual("NG1", method4.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(5).Element.GetType().FullName);
			var method5 = violations.ElementAt(5).Element as Method;
			Assert.AreEqual("NG2", method5.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(6).Element.GetType().FullName);
			var method6 = violations.ElementAt(6).Element as Method;
			Assert.AreEqual("NG2", method6.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(7).Element.GetType().FullName);
			var method7 = violations.ElementAt(7).Element as Method;
			Assert.AreEqual("NG2", method7.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(8).Element.GetType().FullName);
			var method8 = violations.ElementAt(8).Element as Method;
			Assert.AreEqual("NG2", method8.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(9).Element.GetType().FullName);
			var method9 = violations.ElementAt(9).Element as Method;
			Assert.AreEqual("NG2", method9.Declaration.Name);
		}
	}
}
