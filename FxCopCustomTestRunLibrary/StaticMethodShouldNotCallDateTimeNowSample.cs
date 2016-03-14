using System;

namespace FxCopCustomTestRunLibrary
{
	public class StaticMethodShouldNotCallDateTimeNowSample
	{
		public void OK()
		{
			Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
		}

		public static void NG()
		{
			Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
		}
	}
}
