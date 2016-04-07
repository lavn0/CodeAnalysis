using FxCopCustom.Settings;
using Microsoft.FxCop.Sdk;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FxCopCustom.Rules
{
	/// <summary>FxCopのカスタムルールの作成を簡易にするための抽象クラス</summary>
	public abstract class BaseRule : BaseIntrospectionRule
	{
		internal static readonly FxCopSettings Settings;

		private const string FxCopRulesXmlPath = "FxCopCustom.Rules.xml";
		private const string SettingFileName = "fxcopSettings.json";

		static BaseRule()
		{
			var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var fileName = Path.Combine(directory, SettingFileName);

			// BOMを読み込むためにStreamReaderで読み込み、ReadObjectメソッド引き数に使えるようにするためにMemoryStreamに転写する
			using (var sr = new StreamReader(fileName))
			using (var str = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
			{
				var serializer = new DataContractJsonSerializer(typeof(FxCopSettings));
				Settings = (FxCopSettings)serializer.ReadObject(str);
			}
		}

		protected BaseRule(string name)
			: base(name, FxCopRulesXmlPath, typeof(BaseRule).Assembly)
		{
		}

		public override ProblemCollection Check(Member member)
		{
			return base.Check(member) ?? this.Problems; // BaseIntrospectionRule.Check(Member)はnullを返却するので、正しくなるように変更する
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
			this.Violate(node, resolution);
		}

		/// <summary>コード分析エラーとしてマークします</summary>
		/// <param name="resolutionName">解決方法の名前（Name属性）</param>
		/// <param name="node">分析エラー対象ノード</param>
		/// <param name="arguments">解決方法の書式指定オブジェクト</param>
		protected void Violate(string resolutionName, Node node, params object[] arguments)
		{
			var resolution = this.GetNamedResolution(resolutionName, arguments);
			this.Violate(node, resolution);
		}

		private void Violate(Node node, Resolution resolution)
		{
			var problem = CreateProblem(resolution, node);
			this.Problems.Add(problem);

			// デバッグ用にメッセージを出力
			Debug.WriteLine(
				"{0}({1}) : {2}",
				problem.SourceFile,
				problem.SourceLine,
				problem.Resolution.ToString());
		}
	}
}
