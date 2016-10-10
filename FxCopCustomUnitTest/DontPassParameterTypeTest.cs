using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class DontPassParameterTypeTest : BaseFxCopUnitTest
	{
		private const string ruleName = "DontPassParameterType";
		private const string targetTypeName = "DontPassParameterTypeSample";

		[TestMethod]
		public void DontPassParameterTypeTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.AreEqual(1, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
