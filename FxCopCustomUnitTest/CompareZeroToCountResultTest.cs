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
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG1_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("TakeCount", this.GetError(ruleName, targetTypeName, "NG2_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG3_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG4_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("TakeCount", this.GetError(ruleName, targetTypeName, "NG5_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG6_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG7_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("TakeCount", this.GetError(ruleName, targetTypeName, "NG8_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG9_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG10_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("TakeCount", this.GetError(ruleName, targetTypeName, "NG11_TakeCount(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG12_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG13_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("SkipAny", this.GetError(ruleName, targetTypeName, "NG14_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG15_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG16_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("SkipAny", this.GetError(ruleName, targetTypeName, "NG17_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG18_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG19_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG20_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG21_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG22_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG23_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG24_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG25_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG26_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG27_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG28_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG29_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG30_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG31_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("SkipAny", this.GetError(ruleName, targetTypeName, "NG32_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG33_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Any", this.GetError(ruleName, targetTypeName, "NG34_Any(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("SkipAny", this.GetError(ruleName, targetTypeName, "NG35_SkipAny(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual("Error", this.GetError(ruleName, targetTypeName, "NG36_Error(System.Collections.Generic.IEnumerable`1<System.Object>)")?.Attribute("Name").Value);
			Assert.AreEqual(36, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
