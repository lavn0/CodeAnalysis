using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;
using System.Linq;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class PreferAtmarkQuotedStringTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void TestMethod()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\PreferAtmarkQuotedStringTestClass.cs");
			Assert.AreEqual(2, result.Violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Field).FullName, result.Violations.ElementAt(0).Element.GetType().FullName);
			var field = result.Violations.ElementAt(0).Element as Field;
			Assert.AreEqual("Field3", field.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(1).Element.GetType().FullName);
			var method = result.Violations.ElementAt(1).Element as Method;
			Assert.AreEqual("GetField3", method.Declaration.Name);
		}
	}
}
