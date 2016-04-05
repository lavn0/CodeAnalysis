using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class DontUseMethodTest : BaseFxCopUnitTest
	{
		private const string ruleName = "DontUseMethod";
		private const string targetTypeName = "DontUseMethodSample";

		[TestMethod]
		public void DontUseMethodTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.AreEqual(1, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
