﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop.CSharp;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class SpaceAndTabMixedIndentMustNotBeUsedTest
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void SpaceAndTabMixedIndentMustNotBeUsedTest1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\SpaceAndTabMixedIndentMustNotBeUsedTestClass.cs");
			var violations = result.Violations.Where(v => v.Rule.Name == "SpaceAndTabMixedIndentMustNotBeUsed").ToList();
			Assert.AreEqual(5, violations.Count);
			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(0).Element.GetType().FullName);
			var method0 = violations.ElementAt(0).Element as Method;
			Assert.AreEqual("NG1", method0.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(1).Element.GetType().FullName);
			var method1 = violations.ElementAt(1).Element as Method;
			Assert.AreEqual("NG2", method1.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(2).Element.GetType().FullName);
			var method2 = violations.ElementAt(2).Element as Method;
			Assert.AreEqual("NG2", method2.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(3).Element.GetType().FullName);
			var method3 = violations.ElementAt(3).Element as Method;
			Assert.AreEqual("NG3", method3.Declaration.Name);

			Assert.AreEqual(typeof(StyleCop.CSharp.Method).FullName, violations.ElementAt(4).Element.GetType().FullName);
			var method4 = violations.ElementAt(4).Element as Method;
			Assert.AreEqual("NG3", method4.Declaration.Name);
		}
	}
}