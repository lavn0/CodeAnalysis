using StyleCop;
using System.Collections.Generic;

namespace StyleCopContrib.Runner
{
	/// <summary>Container of an analysis results</summary>
	public sealed class AnalysisResults
	{
		/// <summary>Initializes a new instance of the <see cref="AnalysisResults"/> class.</summary>
		/// <param name="codeProjects">The analyzed code project list.</param>
		/// <param name="outputs">The output message list.</param>
		/// <param name="violations">The violation list.</param>
		/// <param name="minuteDuration">Duration of the analysis in minute.</param>
		public AnalysisResults(
			IReadOnlyCollection<CodeProject> codeProjects,
			IReadOnlyCollection<string> outputs,
			IReadOnlyCollection<Violation> violations,
			double minuteDuration)
		{
			this.CodeProjects = codeProjects;
			this.Outputs = outputs;
			this.Violations = violations;
			this.MinuteDuration = minuteDuration;
		}

		/// <summary>Gets the analyzed code project list.</summary>
		/// <value>The code projects.</value>
		public IReadOnlyCollection<CodeProject> CodeProjects { get; private set; }

		/// <summary>Gets the output message list.</summary>
		/// <value>The outputs.</value>
		public IReadOnlyCollection<string> Outputs { get; private set; }

		/// <summary>Gets the violation list.</summary>
		/// <value>The violation list.</value>
		public IReadOnlyCollection<Violation> Violations { get; private set; }

		/// <summary>Gets the duration of the analysis in minute.</summary>
		/// <value>The duration of the minute.</value>
		public double MinuteDuration { get; private set; }
	}
}
