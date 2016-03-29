using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class TestPhoenixRuleTest : BasePhoenixUnitTest
	{
		private const string ruleName = "TestPhoenixRule";
		private const string targetTypeName = "TestPhoenixRuleSample";

		[TestMethod]
		public void TestPhoenixRule1()
		{
			//Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "Test()"), "Test");
			//Assert.AreEqual(1, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
