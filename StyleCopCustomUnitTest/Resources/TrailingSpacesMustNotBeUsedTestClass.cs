using System.Collections.Generic;
using System.Linq;

namespace StyleCopCustomUnitTest.Resources
{
	public static class TrailingSpacesMustNotBeUsedTestClass
	{
		public void OK1()
		{
			return;
		}

		public void NG1()
		{
			return;  
		}

		public void NG2()
		{
			return;	
		}

		public void NG3()
		{
			return;　
		}
	}
}
