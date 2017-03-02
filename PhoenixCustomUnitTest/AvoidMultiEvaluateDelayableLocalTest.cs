using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class AvoidMultiEvaluateDelayableLocalTest : BasePhoenixUnitTest
	{
		private const string ruleName = "AvoidMultiEvaluateDelayableLocal";
		private const string targetTypeName = "AvoidMultiEvaluateDelayableLocalSample";

		[TestMethod]
		public void AvoidMultiEvaluateDelayableLocalTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.AreEqual(1, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
