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
				    ? false
				    : true;
		}

		public bool NG3()
		{
			return true
				 	? false
				 	: true;
		}
	}
}
