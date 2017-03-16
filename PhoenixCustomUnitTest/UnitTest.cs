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
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK2(System.Boolean)").Count, "OK2(System.Boolean)");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "NG3()").Count, "NG3()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK4()").Count, "OK4()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample").Count);
		}

		[TestMethod]
		public void AvoidMultiEvaluateDelayableParameterSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "OK(System.Collections.Generic.IEnumerable`1<System.String>)").Count, "OK(System.Collections.Generic.IEnumerable`1<System.String>)");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "NG1(System.Collections.Generic.IEnumerable`1<System.String>)").Count, "NG1(System.Collections.Generic.IEnumerable`1<System.String>)");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "OK1(System.Collections.Generic.IEnumerable`1<System.String>)").Count, "OK1(System.Collections.Generic.IEnumerable`1<System.String>)");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "OK2(System.Collections.Generic.IEnumerable`1<System.String>,System.Boolean)").Count, "OK2(System.Collections.Generic.IEnumerable`1<System.String>,System.Boolean)");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "OK3(System.Collections.Generic.IEnumerable`1<System.String>)").Count, "OK3(System.Collections.Generic.IEnumerable`1<System.String>)");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "NG4(System.Collections.Generic.List`1<System.String>)").Count, "NG4(System.Collections.Generic.List`1<System.String>)");
			Assert.AreEqual(2, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample").Count);
		}
	}
}