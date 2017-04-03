namespace StyleCopCustomUnitTest.TestSources
{
	public class WideSpaceNotBeUsed
	{
		public void OK1()
		{
			return;
		}

		// ERROR(9,9) 全角空白
		public　void NG1()
		{
			// ERROR(1,4) 全角空白インデント
		　　return;
		}
	}
}
