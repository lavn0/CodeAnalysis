using System.Collections.Generic;
using System.Linq;

namespace StyleCopCustomUnitTest.Resources
{
	public static class SpaceIndentMustNotBeUsedTestClass
	{
		public void OK1()
		{
            return;
		}

		public void NG1()
		{
	        return;
		}

		public string OK2()
		{
			return true
					? false
					: true;
		}

		public string NG2()
		{
			return true
				   ? false
				   : true;
		}

		public string NG3()
		{
			return true
				 	? false
				 	: true;
		}
	}
}
