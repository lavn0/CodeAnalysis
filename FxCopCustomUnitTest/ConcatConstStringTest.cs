using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class ConcatConstStringTest : BaseFxCopUnitTest
	{
		private const string ruleName = "ConcatConstString";
		private const string targetTypeName = "ConcatConstStringSample";

		[TestMethod]
		public void ConcatConstStringTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2()"), "NG2");
			Assert.AreEqual(2, this.GetErrors(ruleName, targetTypeName, "NG3()").Count, "NG3");
			Assert.AreEqual(2, this.GetErrors(ruleName, targetTypeName, "NG4()").Count, "NG4");
			Assert.AreEqual(3, this.GetErrors(ruleName, targetTypeName, "NG5()").Count, "NG5");
			Assert.AreEqual(9, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
