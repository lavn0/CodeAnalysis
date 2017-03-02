using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class EnumerateMethodShouldBeDelayedTest : BasePhoenixUnitTest
	{
		private const string ruleName = "EnumerateMethodShouldBeDelayed";
		private const string targetTypeName = "EnumerateMethodShouldBeDelayedSample";

		[TestMethod]
		public void EnumerateMethodShouldBeDelayedTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.AreEqual(1, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
