using System.Collections.Generic;
using System.Linq;
using FxCopCustom.Rules;
using TestUtility;

namespace FxCopCustomUnitTest
{
	public static partial class CompareZeroToCountResultSample
	{
		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK1_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return source.Count() == 0;
			return !source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "TakeCount")]
		public static bool OK2_TakeCount(IEnumerable<object> source)
		{
			//Take(2).Count() == 1 で書き換えるべき
			//return source.Count() == 1;
			return source.Take(2).Count() == 1;
		}

		//public static bool OK3_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return source.Count() == -1;
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK4_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return 0 == source.Count();
			return !source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "TakeCount")]
		public static bool OK5_TakeCount(IEnumerable<object> source)
		{
			// Take(2).Count() == 1 で書き換えるべき
			//return 1 == source.Count();
			return source.Take(2).Count() == 1;
		}

		//public static bool OK6_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return -1 == source.Count();
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK7_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return source.Count() != 0;
			return source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "TakeCount")]
		public static bool OK8_TakeCount(IEnumerable<object> source)
		{
			// Take(2).Count() != 1 で書き換えるべき
			//return source.Count() != 1;
			return source.Take(2).Count() != 1;
		}

		//public static bool OK9_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return source.Count() != -1;
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK10_Any(IEnumerable<object> source)
		{
			// !Anyで書き換えるべき
			//return 0 != source.Count();
			return source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "TakeCount")]
		public static bool OK11_TakeCount(IEnumerable<object> source)
		{
			// Take(2).Count() == 1 で書き換えるべき
			//return 1 != source.Count();
			return source.Take(2).Count() == 1;
		}

		//public static bool OK12_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return -1 != source.Count();
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK13_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return source.Count() > 0;
			return source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "SkipAny")]
		public static bool OK14_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			//return source.Count() > 1;
			return source.Skip(1).Any();
		}

		//public static bool OK15_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return source.Count() > -1;
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK16_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return 0 < source.Count();
			return source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "SkipAny")]
		public static bool OK17_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			//return 1 < source.Count();
			return source.Skip(1).Any();
		}

		//public static bool OK18_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return -1 < source.Count();
		//}

		//public static bool OK19_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return source.Count() < 0;
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK20_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return source.Count() < 1;
			return !source.Any();
		}

		//public static bool OK21_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return source.Count() < -1;
		//}

		//public static bool OK22_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return 0 > source.Count();
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK23_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			//return 1 > source.Count();
			return !source.Any();
		}

		//public static bool OK24_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return -1 > source.Count();
		//}

		//public static bool OK25_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return source.Count() >= 0;
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK26_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			//return source.Count() >= 1;
			return source.Any();
		}

		//public static bool OK27_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return source.Count() >= -1;
		//}

		//public static bool OK28_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return 0 <= source.Count();
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK29_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			//return 1 <= source.Count();
			return source.Any();
		}

		//public static bool OK30_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にTrue
		//	return -1 <= source.Count();
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK31_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			//return source.Count() <= 0;
			return !source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "SkipAny")]
		public static bool OK32_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			//return source.Count() <= 1;
			return !source.Skip(1).Any();
		}

		//public static bool OK33_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return source.Count() <= -1;
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "Any")]
		public static bool OK34_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			//return 0 >= source.Count();
			return !source.Any();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 0, ResolutionName = "SkipAny")]
		public static bool OK35_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			//return 1 >= source.Count();
			return !source.Skip(1).Any();
		}

		//public static bool OK36_Error(IEnumerable<object> source)
		//{
		//	// バグ。常にFalse
		//	return -1 >= source.Count();
		//}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG1_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return source.Count() == 0;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "TakeCount")]
		public static bool NG2_TakeCount(IEnumerable<object> source)
		{
			//Take(2).Count() == 1 で書き換えるべき
			return source.Count() == 1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG3_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return source.Count() == -1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG4_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return 0 == source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "TakeCount")]
		public static bool NG5_TakeCount(IEnumerable<object> source)
		{
			// Take(2).Count() == 1 で書き換えるべき
			return 1 == source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG6_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return -1 == source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG7_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return source.Count() != 0;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "TakeCount")]
		public static bool NG8_TakeCount(IEnumerable<object> source)
		{
			// Take(2).Count() != 1 で書き換えるべき
			return source.Count() != 1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG9_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return source.Count() != -1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG10_Any(IEnumerable<object> source)
		{
			// !Anyで書き換えるべき
			return 0 != source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "TakeCount")]
		public static bool NG11_TakeCount(IEnumerable<object> source)
		{
			// Take(2).Count() == 1 で書き換えるべき
			return 1 != source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG12_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return -1 != source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG13_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return source.Count() > 0;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "SkipAny")]
		public static bool NG14_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			return source.Count() > 1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG15_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return source.Count() > -1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG16_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return 0 < source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "SkipAny")]
		public static bool NG17_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			return 1 < source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG18_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return -1 < source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG19_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return source.Count() < 0;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG20_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return source.Count() < 1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG21_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return source.Count() < -1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG22_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return 0 > source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG23_Any(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return 1 > source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG24_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return -1 > source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG25_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return source.Count() >= 0;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG26_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			return source.Count() >= 1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG27_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return source.Count() >= -1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG28_Error(IEnumerable<object> source)
		{
			// Anyで書き換えるべき
			return 0 <= source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG29_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			return 1 <= source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG30_Error(IEnumerable<object> source)
		{
			// バグ。常にTrue
			return -1 <= source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG31_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			return source.Count() <= 0;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "SkipAny")]
		public static bool NG32_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			return source.Count() <= 1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG33_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return source.Count() <= -1;
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Any")]
		public static bool NG34_Any(IEnumerable<object> source)
		{
			// Any()で書き換えるべき
			return 0 >= source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "SkipAny")]
		public static bool NG35_SkipAny(IEnumerable<object> source)
		{
			// Skip(1).Any()で書き換えるべき
			return 1 >= source.Count();
		}

		[TestInfo(TargetRuleName = nameof(CompareZeroToCountResult), ViolationCount = 1, ResolutionName = "Error")]
		public static bool NG36_Error(IEnumerable<object> source)
		{
			// バグ。常にFalse
			return -1 >= source.Count();
		}
	}
}
