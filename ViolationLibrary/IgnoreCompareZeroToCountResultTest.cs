﻿using System.Collections.Generic;
using System.Linq;

namespace ViolationLibrary
{
	/// <summary>Countメソッドの結果を利用するサンプル</summary>
	public static class IgnoreCompareZeroToCountResultTest
	{
		public static List<string> GetSample()
		{
			return new List<string>() { "1", "2", "3" };
		}

		public static List<string> OK1()
		{
			var ls = GetSample().ToList();
			var result = ls.Count > 0;
			ls.Add(result.ToString());
			return ls;
		}

		public static List<string> OK2()
		{
			var ls = GetSample().ToList();
			var result = ls.Count >= 0;
			ls.Add(result.ToString());
			return ls;
		}

		public static List<string> OK3()
		{
			var ls = GetSample().ToList();
			var result = ls.Count < 0;
			ls.Add(result.ToString());
			return ls;
		}

		public static List<string> OK4()
		{
			var ls = GetSample().ToList();
			var result = ls.Count <= 0;
			ls.Add(result.ToString());
			return ls;
		}

		public static List<string> OK5()
		{
			var ls = GetSample().ToList();
			var result = ls.Count == 0;
			ls.Add(result.ToString());
			return ls;
		}

		public static bool NG1()
		{
			return GetSample().Count() > 0;
		}

		public static bool NG2()
		{
			return GetSample().Count() >= 0;
		}

		public static bool NG3()
		{
			return GetSample().Count() < 0;
		}

		public static bool NG4()
		{
			return GetSample().Count() <= 0;
		}

		public static bool NG5()
		{
			return GetSample().Count() == 0;
		}
	}
}
