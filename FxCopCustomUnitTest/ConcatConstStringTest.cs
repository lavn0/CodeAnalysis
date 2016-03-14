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
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ConcatConstStringSample_NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ConcatConstStringSample_NG2()"), "NG2");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ConcatConstStringSample_NG3()"), "NG3");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ConcatConstStringSample_NG4()"), "NG4");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ConcatConstStringSample_NG5()"), "NG5");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ConcatConstStringSample_NG6()"), "NG6");
			Assert.AreEqual(6, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
