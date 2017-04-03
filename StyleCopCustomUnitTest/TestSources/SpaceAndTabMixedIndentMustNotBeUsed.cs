namespace StyleCopCustomUnitTest.TestSources
{
	public class SpaceAndTabMixedIndentMustNotBeUsed
	{
		public void OK1()
		{
            return;
		}

		public void NG1()
		{
			// ERROR(1,9) 半角空白、タブの混在インデント
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
				// ERROR(1,7) 途中でタブから半角空白に切り替わる混在インデント
				   ? false
				// ERROR(1,7) 途中でタブから半角空白に切り替わる混在インデント
				   : true;
		}

		public bool NG3()
		{
			return true
				// ERROR(1,6) タブの途中に半角空白が混ざった混在インデント
				 	? false
				// ERROR(1,6) タブの途中に半角空白が混ざった混在インデント
				 	: true;
		}
	}
}
