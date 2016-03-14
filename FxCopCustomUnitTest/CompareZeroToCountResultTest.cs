using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class CompareZeroToCountResultTest : BaseFxCopUnitTest
	{
		private const string ruleName = "CompareZeroToCountResult";
		private const string targetTypeName = "CompareZeroToCountResultSample";

		[TestMethod]
		public void CompareZeroToCountResultTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG2()"), "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG3()"), "NG3");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG4()"), "NG4");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG5()"), "NG5");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG6()"), "NG6");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG7()"), "NG7");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG8()"), "NG8");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG9()"), "NG9");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CompareZeroToCountResultSample_NG10()"), "NG10");
			Assert.AreEqual(10, this.GetErrors(ruleName, targetTypeName).Count);
		}

		[TestMethod]
		public void IgnoreCompareZeroToCountResultTest2()
		{
			const string targetTypeName2 = "IgnoreCompareZeroToCountResultSample1";
			Assert.AreEqual(0, this.GetErrors(ruleName, targetTypeName2).Count);
		}

		[TestMethod]
		public void IgnoreCompareZeroToCountResultTest3()
		{
			const string targetTypeName3 = "IgnoreCompareZeroToCountResultSample2";
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG2()"), "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG3()"), "NG3");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG4()"), "NG4");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG5()"), "NG5");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG6()"), "NG6");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG7()"), "NG7");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG8()"), "NG8");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG9()"), "NG9");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName3, "NG10()"), "NG10");
			Assert.AreEqual(10, this.GetErrors(ruleName, targetTypeName3).Count);
		}
	}
}
