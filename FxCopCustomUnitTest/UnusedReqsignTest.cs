using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class UnusedReqsignTest : BaseFxCopUnitTest
	{
		private const string ruleName = "UnusedReqsignTest";
		private const string targetTypeName = "UnusedReqsignTestSample";

		[TestMethod]
		public void UnusedReqsignTestTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2()"), "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG3()"), "NG3");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG4()"), "NG4");
			Assert.AreEqual(4, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
