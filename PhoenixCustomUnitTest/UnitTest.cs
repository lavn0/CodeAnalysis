using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class PhoenixCustomUnitTest : BasePhoenixUnitTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void AvoidDoubleCastSample()
		{
			Assert.AreEqual(1, this.GetErrors("AvoidDoubleCast", "AvoidDoubleCastSample", "NG1(System.Collections.Generic.IEnumerable`1<System.String>,System.String,System.String)").Count, "NG1(System.Collections.Generic.IEnumerable`1<System.String>,System.String,System.String)");
			Assert.AreEqual(0, this.GetErrors("AvoidDoubleCast", "AvoidDoubleCastSample", "OK1(System.Collections.Generic.IEnumerable`1<System.String>,System.String)").Count, "OK1(System.Collections.Generic.IEnumerable`1<System.String>,System.String)");
			Assert.AreEqual(0, this.GetErrors("AvoidDoubleCast", "AvoidDoubleCastSample", "OK2(System.Collections.Generic.IEnumerable`1<System.String>)").Count, "OK2(System.Collections.Generic.IEnumerable`1<System.String>)");
			Assert.AreEqual(1, this.GetErrors("AvoidDoubleCast", "AvoidDoubleCastSample").Count);
		}

		[TestMethod]
		public void AvoidMultiCalculatePureMethodSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "OK2()").Count, "OK2()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "OK3()").Count, "OK3()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "OK4()").Count, "OK4()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample", "NG3()").Count, "NG3()");
			Assert.AreEqual(3, this.GetErrors("AvoidMultiCalculatePureMethod", "AvoidMultiCalculatePureMethodSample").Count);
		}

		[TestMethod]
		public void AvoidMultiEvaluateDelayableLocalSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK()").Count, "OK()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableLocal", "AvoidMultiEvaluateDelayableLocalSample", "OK1_2(System.Collections.Generic.IEnumerable`1<System.String>)").Count, "OK1_2(System.Collections.Generic.IEnumerable`1<System.String>)");
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
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample", "OK4(System.Collections.Generic.List`1<System.String>)").Count, "OK4(System.Collections.Generic.List`1<System.String>)");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluateDelayableParameter", "AvoidMultiEvaluateDelayableParameterSample").Count);
		}

		[TestMethod]
		public void AvoidMultiEvaluatePerformanceCliticalMethodSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidMultiEvaluatePerformanceCriticalMethod", "AvoidMultiEvaluatePerformanceCliticalMethodSample", "OK()").Count, "OK()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluatePerformanceCriticalMethod", "AvoidMultiEvaluatePerformanceCliticalMethodSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiEvaluatePerformanceCriticalMethod", "AvoidMultiEvaluatePerformanceCliticalMethodSample").Count);
		}

		[TestMethod]
		public void AvoidMultiGetPropertySample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample", "OK1()").Count, "OK1()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample", "NG1()").Count, "NG1()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample", "OK2()").Count, "OK2()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample", "OK3()").Count, "OK3()");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample", "OK4(System.Boolean)").Count, "OK4(System.Boolean)");
			Assert.AreEqual(0, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample", "NG3()").Count, "NG3()");
			Assert.AreEqual(1, this.GetErrors("AvoidMultiGetProperty", "AvoidMultiGetPropertySample").Count);
		}

		[TestMethod]
		public void AvoidNonNullMethodResultComparedByNullSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample", "OK2()").Count, "OK2()");
			Assert.AreEqual(0, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample", "OK3(System.Boolean)").Count, "OK3(System.Boolean)");
			Assert.AreEqual(1, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(1, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(2, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample", "NG3(System.Boolean)").Count, "NG3(System.Boolean)");
			Assert.AreEqual(4, this.GetErrors("AvoidNonNullMethodResultComparedByNull", "AvoidNonNullMethodResultComparedByNullSample").Count);
		}

		[TestMethod]
		public void AvoidReasignLocalWithoutUsedSample()
		{
			Assert.AreEqual(0, this.GetErrors("AvoidReasignLocalWithoutUsed", "AvoidReasignLocalWithoutUsedSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("AvoidReasignLocalWithoutUsed", "AvoidReasignLocalWithoutUsedSample", "OK2(System.Boolean)").Count, "OK2(System.Boolean)");
			Assert.AreEqual(1, this.GetErrors("AvoidReasignLocalWithoutUsed", "AvoidReasignLocalWithoutUsedSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(2, this.GetErrors("AvoidReasignLocalWithoutUsed", "AvoidReasignLocalWithoutUsedSample", "NG2()").Count, "NG2()");
			Assert.AreEqual(1, this.GetErrors("AvoidReasignLocalWithoutUsed", "AvoidReasignLocalWithoutUsedSample", "NG3(System.Boolean)").Count, "NG3(System.Boolean)");
			Assert.AreEqual(4, this.GetErrors("AvoidReasignLocalWithoutUsed", "AvoidReasignLocalWithoutUsedSample").Count);
		}

		[TestMethod]
		public void EnumerateMethodShouldBeDelayedSample()
		{
			Assert.AreEqual(0, this.GetErrors("EnumerateMethodShouldBeDelayed", "EnumerateMethodShouldBeDelayedSample", "OK()").Count, "OK()");
			Assert.AreEqual(1, this.GetErrors("EnumerateMethodShouldBeDelayed", "EnumerateMethodShouldBeDelayedSample", "NG1()").Count, "NG1()");
			Assert.AreEqual(0, this.GetErrors("EnumerateMethodShouldBeDelayed", "EnumerateMethodShouldBeDelayedSample", "OK1()").Count, "OK1()");
			Assert.AreEqual(0, this.GetErrors("EnumerateMethodShouldBeDelayed", "EnumerateMethodShouldBeDelayedSample", "OK2()").Count, "OK2()");
			Assert.AreEqual(1, this.GetErrors("EnumerateMethodShouldBeDelayed", "EnumerateMethodShouldBeDelayedSample").Count);
		}
	}
}