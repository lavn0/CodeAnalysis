using System.Collections.Generic;
using System.Linq;

namespace StyleCopCustomUnitTest.Resources
{
	public static class PreferAtmarkQuotedStringTestClass
	{
		public static string Field1 = "TestData";
		public static string Field2 = "Test\tData";
		public static string Field3 = "Test\\tData";
		public static string Field4 = "Test\\\tData";
		public static string Field5 = @"TestData";
		public static string Field6 = @"Test\tData";

		public string GetField1()
		{
			return "TestData";
		}

		public string GetField2()
		{
			return "Test\tData";
		}

		public string GetField3()
		{
			return "Test\\tData";
		}

		public string GetField4()
		{
			return "Test\\\tData";
		}

		public string GetField5()
		{
			return @"TestData";
		}

		public string GetField6()
		{
			return @"Test\tData";
		}
	}
}
