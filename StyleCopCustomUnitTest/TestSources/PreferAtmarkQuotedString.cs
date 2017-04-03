namespace StyleCopCustomUnitTest.TestSources
{
	public class PreferAtmarkQuotedString
	{
		public static string Field1 = "TestData";
		public static string Field2 = "Test\tData";
		// ERROR(33,45) "Test\\tData"
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
			// ERROR(11,23) "Test\\tData"
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
