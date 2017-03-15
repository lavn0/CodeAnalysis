using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class PhoenixCustomUnitTest : BasePhoenixUnitTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void AvoidMultiEvaluateDelayableLocalSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK()").Count, "OK()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK2(flg)").Count, "OK2(flg)");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "NG3()").Count, "NG3()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK4()").Count, "OK4()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample").Count);
		}
	}
}