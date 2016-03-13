using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class CompareZeroToCountResultTest : BaseFxCopUnitTest
	{
		[TestMethod]
		public void MethodErrorsTest()
		{
			var methodErrors = this.GetMethodErrors("CompareZeroToCountResult");
			Assert.AreEqual(10, methodErrors.Count);
		}
	}
}
