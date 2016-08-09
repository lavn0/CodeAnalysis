using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;
using System.Linq;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class NumberAmoountRuleTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void NumberAmoountRuleTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\NumberAmoountRuleTestClass.cs");
			Assert.AreEqual(4, result.Violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Field).FullName, result.Violations.ElementAt(0).Element.GetType().FullName);
			var field = result.Violations.ElementAt(0).Element as Field;
			Assert.AreEqual("NGField", field.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(1).Element.GetType().FullName);
			var method1 = result.Violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NGNumberLocal", method1.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(2).Element.GetType().FullName);
			var method2 = result.Violations.ElementAt(2).Element as Method;
			Assert.AreEqual("NGInitParams", method2.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(3).Element.GetType().FullName);
			var method3 = result.Violations.ElementAt(3).Element as Method;
			Assert.AreEqual("NGExpression", method3.Declaration.Name);
		}
	}
}
