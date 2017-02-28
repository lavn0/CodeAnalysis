using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class AvoidReasignLocalWithoutUsedTest : BasePhoenixUnitTest
	{
		private const string ruleName = "AvoidReasignLocalWithoutUsed";
		private const string targetTypeName = "AvoidReasignLocalWithoutUsedSample";

		[TestMethod]
		public void AvoidReasignLocalWithoutUsedTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.AreEqual(2, this.GetErrors(ruleName, targetTypeName, "NG2()").Count, "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG3(System.Boolean)"), "NG3");
			Assert.AreEqual(4, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
