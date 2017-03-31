namespace StyleCopCustomUnitTest.Resources
{
	public class SpaceIndentMustNotBeUsedTestClass
	{
		public void OK1()
		{
			return;
		}

		public void NG1()
		{
			// ERROR(1,12) 半角インデント
            return;
		}

		public bool OK2()
		{
			return true
				   ? false
				   : true;
		}

		public bool NG2()
		{
			return true
				// ERROR(1,8) タブに変更できる分のインデント
				    ? false
				// ERROR(1,8) タブに変更できる分のインデント
				    : true;
		}

		public bool NG3()
		{
			return true
				// ERROR(1,6) 半角空白、タブの混在インデント
				 	? false
				// ERROR(1,6) 半角空白、タブの混在インデント
				 	: true;
		}
	}
}
