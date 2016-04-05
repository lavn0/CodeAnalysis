using System.Collections.Generic;
using System.Linq;

namespace FxCopCustomTestRunLibrary
{
	public static class DontUseMethodSample
	{
		private static void DontUseMethodCall()
		{
		}

		public static void OK()
		{
			new List<string>().ToList();
		}

		public static void NG1()
		{
			DontUseMethodCall();
		}
	}
}
