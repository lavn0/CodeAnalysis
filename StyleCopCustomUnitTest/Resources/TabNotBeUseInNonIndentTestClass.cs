namespace StyleCopCustomUnitTest.Resources
{
	public class TabNotBeUseInNonIndentTestClass
	{
		public bool OK(bool flg)
		{
			return flg ? true : false;
		}

		public bool NG(bool flg)
		{
			return flg ? true :	false;	
		}
	}
}
