﻿using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using PhoenixCustom.Rules;
using TestUtility;

namespace PhoenixCustomUnitTest.TestSources
{
	public class AvoidMultiCalculatePureMethodSample
	{
		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 0)]
		public void OK1()
		{
			// プロパティの呼び出しは別のルールで判定
			var a = List;
			var b = List;
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 0)]
		public void OK2()
		{
			// Pure属性もなく、設定ファイルでもPureとしてマークされていないメソッドは何度呼び出してもOK
			var a = GetList();
			var b = GetList();
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 1)]
		public void NG1()
		{
			// Pure属性があるメソッドは結果を取り直してはいけない
			var a = GetListAttributedPure();
			var b = GetListAttributedPure();
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 1)]
		public void NG2()
		{
			// 設定ファイルでPureとしてマークされたメソッドは結果を取り直してはいけない
			var a = GetListMarkedPure();
			var b = GetListMarkedPure();
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 0)]
		public void OK3()
		{
			// メソッドが違えば結果が違うので問題ない
			var a = GetListMarkedPure("a", "b");
			var b = GetListMarkedPure();
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 0)]
		public void OK4()
		{
			// パラメータが違えば結果が違うので問題ない
			var a = GetListMarkedPure("a", "b");
			var b = GetListMarkedPure("a", "c");
			var c = GetListMarkedPure("c", "b");
		}

		[TestInfo(TargetRuleName = nameof(AvoidMultiCalculatePureMethod), ViolationCount = 1)]
		public void NG3()
		{
			// パラメータが同じなら結果が同じなので取り直してはいけない
			var a = GetListMarkedPure("a", "b");
			var b = GetListMarkedPure("a", "b");
		}

		private List<string> GetList()
		{
			return new[] { "a", "b", "c" }.ToList();
		}

		[Pure]
		private List<string> GetListAttributedPure()
		{
			return new[] { "a", "b", "c" }.ToList();
		}

		private List<string> GetListMarkedPure()
		{
			return new[] { "a", "b", "c" }.ToList();
		}

		private List<string> GetListMarkedPure(string param1, string param2)
		{
			return new[] { param1, param2 }.ToList();
		}

		private List<string> List
		{
			get { return new[] { "a", "b", "c" }.ToList(); }
		}
	}
}
