using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class LinqResultComparedByNullTest : BaseFxCopUnitTest
	{
		private const string ruleName = "LinqResultComparedByNull";
		private const string targetTypeName = "LinqResultComparedByNullSample";

		[TestMethod]
		public void LinqResultComparedByNullTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG1()"), "NG1");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "NG2()"), "NG2");
			Assert.AreEqual(2, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
