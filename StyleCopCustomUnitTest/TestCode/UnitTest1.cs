using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCopContrib.Runner;

namespace StyleCopCustomUnitTest
{
	[TestClass]
	public class UnitTest1
	{
		private const string settingPath = "NullSettings.StyleCop";

		[TestMethod]
		public void TestMethod1()
		{
			var result = StyleCopUtil.RunStyleCop(settingPath, @"Resources\Class1.cs");
			Assert.AreEqual(0, result.Violations.Count);
		}
	}
}
