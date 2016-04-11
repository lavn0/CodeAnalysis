using System;

namespace FxCopCustomTestRunLibrary
{
	class NeedToCatchSample
	{
		// 正しくcatchされている
		public void OK1()
		{
			try
			{
				int.Parse("1.5");
			}
			catch (ArgumentNullException)
			{
			}
		}

		// 2個目のcatch句でcatchされている
		public void OK2()
		{
			try
			{
				int.Parse("1.5");
			}
			catch (InvalidOperationException)
			{
			}
			catch (ArgumentNullException)
			{
			}
		}

		// try句にも囲まれていない
		public void NG1()
		{
			int.Parse("1.5");
		}

		// try句に囲まれているが、catch句が無い
		public void NG2()
		{
			try
			{
				int.Parse("1.5");
			}
			finally
			{
			}
		}

		// catchされている型が違う
		public void NG3()
		{
			try
			{
				int.Parse("1.5");
			}
			catch (InvalidOperationException)
			{
			}
		}

		// 外側のcatch句でcatchされている
		public void NG4()
		{
			try
			{
				try
				{
					int.Parse("1.5");
				}
				catch (InvalidOperationException)
				{
				}
			}
			catch (ArgumentNullException)
			{
			}
		}
	}
}
