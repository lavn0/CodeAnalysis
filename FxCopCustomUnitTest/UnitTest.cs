using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class FxCopCustomUnitTest : BaseFxCopUnitTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void AsignedConstOnlySample()
		{
			Assert.AreEqual(1, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "NG2()").Count, "NG2()");
			Assert.AreEqual(1, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "NG3()").Count, "NG3()");
			Assert.AreEqual(0, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "OK2()").Count, "OK2()");
			Assert.AreEqual(0, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample", "OK3()").Count, "OK3()");
			Assert.AreEqual(3, this.GetErrors("AsignedConstOnly", "AsignedConstOnlySample").Count);
		}
	}
}