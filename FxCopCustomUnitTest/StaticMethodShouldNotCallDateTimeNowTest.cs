using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class StaticMethodShouldNotCallDateTimeNowTest : BaseFxCopUnitTest
	{
		private const string ruleName = "StaticMethodShouldNotCallDateTimeNow";
		private const string targetTypeName = "StaticMethodShouldNotCallDateTimeNowSample";

		[TestMethod]
		public void StaticMethodShouldNotCallDateTimeNowTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG()"), "NG");
			Assert.AreEqual(1, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
