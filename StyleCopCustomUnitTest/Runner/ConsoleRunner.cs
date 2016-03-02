using StyleCop;
using System;
using System.Collections.Generic;

namespace StyleCopContrib.Runner
{
	/// <summary>StyleCopConsoleのラッパクラス</summary>
	public sealed class ConsoleRunner
	{
		private readonly StyleCopConsole console;
		private readonly List<string> outputs;
		private readonly List<Violation> violations;

		public ConsoleRunner(string settingsPath, string outputPath)
		{
			var addinPaths = new List<string>();
			this.console = new StyleCopConsole(settingsPath, false, outputPath, addinPaths, true);

			this.outputs = new List<string>();
			this.violations = new List<Violation>();
		}

		public StyleCopEnvironment Environment
		{
			get { return this.console.Core.Environment; }
		}

		public AnalysisResults Analyze(CodeProject codeProject)
		{
			return this.Analyze(new List<CodeProject> { codeProject });
		}

		/// <summary>
		/// Analyzes the specified code projects.
		/// </summary>
		/// <param name="codeProjects">The code projects.</param>
		/// <returns>The <see cref="AnalysisResults"/> object of the analyzed <see cref="CodeProject"/> list.</returns>
		public AnalysisResults Analyze(IReadOnlyCollection<CodeProject> codeProjects)
		{
			if (codeProjects == null)
			{
				throw new ArgumentNullException("codeProjects");
			}

			this.console.ViolationEncountered += (sender, args) => this.AddViolation(args.Violation);
			this.console.OutputGenerated += (sender, args) => this.AddOutput(args.Output);

			DateTime start = DateTime.Now;

			this.console.Start(new List<CodeProject>(codeProjects), true);

			DateTime end = DateTime.Now;

			return new AnalysisResults(codeProjects, this.outputs, this.violations, end.Subtract(start).TotalSeconds);
		}

		private void AddOutput(string output)
		{
			this.outputs.Add(output);
		}

		private void AddViolation(Violation violation)
		{
			this.violations.Add(violation);
		}
	}
}
