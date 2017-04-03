namespace StyleCopCustomUnitTest.TestSources
{
	public class TabNotBeUseInNonIndent
	{
		public bool OK(bool flg)
		{
			return flg ? true : false;
		}

		public bool NG(bool flg)
		{
			// ERROR()
			return flg ? true :	false;	
		}
	}
}
