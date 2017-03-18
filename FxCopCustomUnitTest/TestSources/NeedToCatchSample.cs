using System;
using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomTestRunLibrary
{
	class NeedToCatchSample
	{
		// 正しくcatchされている
		[TestInfo(TargetRuleName = nameof(NeedToCatch), ViolationCount = 0)]
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
		[TestInfo(TargetRuleName = nameof(NeedToCatch), ViolationCount = 0)]
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
		[TestInfo(TargetRuleName = nameof(NeedToCatch), ViolationCount = 1)]
		public void NG1()
		{
			int.Parse("1.5");
		}

		// try句に囲まれているが、catch句が無い
		[TestInfo(TargetRuleName = nameof(NeedToCatch), ViolationCount = 1)]
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
		[TestInfo(TargetRuleName = nameof(NeedToCatch), ViolationCount = 1)]
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
		[TestInfo(TargetRuleName = nameof(NeedToCatch), ViolationCount = 1)]
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
