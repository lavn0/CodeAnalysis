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
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG3()"), "NG3");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG4()"), "NG4");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG5()"), "NG5");
			Assert.AreEqual(5, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
