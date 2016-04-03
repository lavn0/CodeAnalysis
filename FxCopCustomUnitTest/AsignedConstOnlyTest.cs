﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class AsignedConstOnlyTest : BaseFxCopUnitTest
	{
		private const string ruleName = "AsignedConstOnly";
		private const string targetTypeName = "AsignedConstOnlySample";

		[TestMethod]
		public void AsignedConstOnlyTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2()"), "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG3()"), "NG3");
			Assert.AreEqual(3, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}