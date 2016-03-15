using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class UnusedReasignTest : BaseFxCopUnitTest
	{
		private const string ruleName = "UnusedReasign";
		private const string targetTypeName = "UnusedReasignSample";

		[TestMethod]
		public void UnusedReasignTestTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2()"), "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG3()"), "NG3");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG4()"), "NG4");
			Assert.AreEqual(4, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
