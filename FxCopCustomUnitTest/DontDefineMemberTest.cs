using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FxCopCustomUnitTest
{
	[TestClass]
	public class DontDefineMemberTest : BaseFxCopUnitTest
	{
		private const string ruleName = "DontDefineMember";
		private const string targetTypeName = "DontDefineMemberSample";

		[TestMethod]
		public void DontDefineMemberTest1()
		{
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "IsFieldNG"), "IsFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "IsPropertyNG"), "IsPropertyNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "IsMethodNG()"), "IsMethodNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CanFieldNG"), "CanFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "HasFieldNG"), "HasFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ShouldFieldNG"), "ShouldFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CouldFieldNG"), "CouldFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "WillFieldNG"), "WillFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ShallFieldNG"), "ShallFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "CheckFieldNG"), "CheckFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "ContainsFieldNG"), "ContainsFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "EqualsFieldNG"), "EqualsFieldNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "StartsWithNG()"), "StartsWithNG");
			Assert.IsNotNull(this.GetError(ruleName, targetTypeName, "EndsWith()"), "EndsWith");
			Assert.AreEqual(14, this.GetErrors(ruleName, targetTypeName).Count);
		}
	}
}
