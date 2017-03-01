using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class AvoidMultiEvaluateDelayableParameterTest : BasePhoenixUnitTest
	{
		private const string ruleName = "AvoidMultiEvaluateDelayableParameter";
		private const string targetTypeName = "AvoidMultiEvaluateDelayableParameterSample";

		[TestMethod]
		public void AvoidMultiEvaluateDelayableParameterTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1(System.Collections.Generic.IEnumerable`1<System.String>)"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2(System.Collections.Generic.IEnumerable`1<System.String>,System.Boolean)"), "NG2");
			Assert.AreEqual(2, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
