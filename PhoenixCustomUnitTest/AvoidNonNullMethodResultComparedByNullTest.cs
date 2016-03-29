using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixCustomUnitTest
{
	[TestClass]
	public class AvoidNonNullMethodResultComparedByNullTest : BasePhoenixUnitTest
	{
		private const string ruleName = "AvoidNonNullMethodResultComparedByNull";
		private const string targetTypeName = "AvoidNonNullMethodResultComparedByNullSample";

		[TestMethod]
		public void AvoidNonNullMethodResultComparedByNullTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2()"), "NG2");
			Assert.AreEqual(2, this.GetErrors(ruleName, targetTypeName, "NG3(System.Boolean)").Count, "NG3");
			Assert.AreEqual(4, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
