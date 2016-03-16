using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Phx.IR;
using System.Diagnostics;

namespace PhoenixCustom
{
	internal abstract class BasePhoenixCustomRule : PhoenixRule
	{
		private readonly StatisticsService m_statisticsService;

		public BasePhoenixCustomRule(StatisticsService statisticsService)
		{
			this.m_statisticsService = statisticsService;
		}

		protected void Violate(WarningEmitter warningEmitter, Instruction instruction)
		{
			var violationMessage = this.ReportLocalizedWarning(instruction);
			var sourceContext = instruction.GetSourceContext();
			Debug.WriteLine(
				"{0}({1}) : {2}",
				sourceContext.FileName,
				sourceContext.LineNumber,
				violationMessage.DescriptionString);
			warningEmitter.Add(violationMessage);
		}
	}
}
