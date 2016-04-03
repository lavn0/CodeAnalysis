using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;
using System.Linq;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class XmlCommentRuleTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void XmlCommentRuleTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\XmlCommentRuleTestClass.cs");

			Assert.AreEqual(typeof(Property).FullName, result.Violations.ElementAt(0).Element.GetType().FullName);
			var property1 = result.Violations.ElementAt(0).Element as Property;
			Assert.AreEqual("NG1", property1.Declaration.Name);

			Assert.AreEqual(typeof(Property).FullName, result.Violations.ElementAt(1).Element.GetType().FullName);
			var property2 = result.Violations.ElementAt(1).Element as Property;
			Assert.AreEqual("NG2", property2.Declaration.Name);

			Assert.AreEqual(typeof(Property).FullName, result.Violations.ElementAt(2).Element.GetType().FullName);
			var property3 = result.Violations.ElementAt(2).Element as Property;
			Assert.AreEqual("NG3", property3.Declaration.Name);

			Assert.AreEqual(3, result.Violations.Count);
		}
	}
}
