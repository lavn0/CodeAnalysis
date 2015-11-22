using Microsoft.FxCop.Sdk;
using System;
using System.Diagnostics;

namespace FxCopCustom.Rules
{
	/// <summary>FxCopのカスタムルールの作成を簡易にするための抽象クラス</summary>
	public abstract class BaseRule : BaseIntrospectionRule
	{
		private const string FxCopRulesXmlPath = "FxCopCustom.Rules.xml";

		protected BaseRule(string name)
			: base(name, FxCopRulesXmlPath, typeof(BaseRule).Assembly)
		{
		}

		public override void AfterAnalysis()
		{
			// デバッグ用にメッセージを出力
			foreach (var problem in this.Problems)
			{
				Debug.WriteLine(
					"{0}({1}) : {2}",
					problem.SourceFile,
					problem.SourceLine,
					problem.Resolution.ToString());
			}

			base.AfterAnalysis();
		}

		/// <summary>指定のソースコードの情報を設定した<see cref="Problem"/>を作成します。</summary>
		/// <param name="resolution">解決方法</param>
		/// <param name="node">ノード</param>
		/// <returns>Problemインスタンス</returns>
		protected static Problem CreateProblem(Resolution resolution, Node node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}

			return new Problem(resolution)
			{
				SourceFile = node.SourceContext.FileName,
				SourceLine = node.SourceContext.StartLine,
			};
		}

		/// <summary>コード分析エラーとしてマークします</summary>
		/// <param name="node">分析エラー対象ノード</param>
		/// <param name="arguments">解決方法の書式指定オブジェクト</param>
		protected void Violate(Node node, params object[] arguments)
		{
			var resolution = this.GetResolution(arguments);
			var problem = CreateProblem(resolution, node);
			this.Problems.Add(problem);
		}

		/// <summary>コード分析エラーとしてマークします</summary>
		/// <param name="resolutionName">解決方法の名前（Name属性）</param>
		/// <param name="node">分析エラー対象ノード</param>
		/// <param name="arguments">解決方法の書式指定オブジェクト</param>
		protected void Violate(string resolutionName, Node node, params object[] arguments)
		{
			var resolution = this.GetNamedResolution(resolutionName, arguments);
			var problem = CreateProblem(resolution, node);
			this.Problems.Add(problem);
		}
	}
}
