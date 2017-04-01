namespace StyleCopCustomUnitTest.Resources
{
	public class TrailingSpacesMustNotBeUsedTestClass
	{
		public void OK0()
		{
			return;
		}

		public string OK1()
		{
			return @"  
";
		}

		public string OK2()
		{
			return @"	
";
		}

		public string OK3()
		{
			return @"　
";
		}

		public void NG1()
		{
			// ERROR(11,12) 末尾の半角空白
			return;  
		}

		public void NG2()
		{
			// ERROR(11,11) 末尾のタブ
			return;	
		}

		public void NG3()
		{
			// ERROR(11,11) 末尾の全角空白
			return;　
		}
	}
}
