using Microsoft.VisualStudio.CodeAnalysis.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Phx;

namespace PhoenixCustom
{
	/// <summary>実験的に実装された最低限の設定のPhoenixRule</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0000", typeof(ReliabilityCategory))]
	internal sealed class TestPhoenixRule : BasePhoenixCustomRule
	{
		public TestPhoenixRule(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			//this.Violate(warningEmitter, functionUnit.FirstInstruction);
		}
	}
}
