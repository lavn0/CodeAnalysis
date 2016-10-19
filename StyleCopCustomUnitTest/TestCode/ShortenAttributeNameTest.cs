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
			Assert.AreEqual(1, result.Violations.Count);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, result.Violations.ElementAt(0).Element.GetType().FullName);
			var method = result.Violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG", method.Declaration.Name);
		}
	}
}
