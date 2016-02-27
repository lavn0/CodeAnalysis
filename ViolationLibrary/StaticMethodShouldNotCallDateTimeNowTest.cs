using System;

namespace ViolationLibrary
{
	public class StaticMethodShouldNotCallDateTimeNowTest
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
