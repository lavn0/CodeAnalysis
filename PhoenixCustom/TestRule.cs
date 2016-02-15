using Microsoft.VisualStudio.CodeAnalysis.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Phx;

namespace PhoenixCustom
{
	/// <summary>実験的に実装された最低限の設定のPhoenixRule</summary>
	[LocalizedFxCopRule("PhenixCustom.XX0001", typeof(ReliabilityCategory))]
	internal sealed class TestRule : PhoenixRule
	{
	private readonly StatisticsService m_statisticsService;

	public TestRule(StatisticsService statisticsService)
	{
		this.m_statisticsService = statisticsService;
	}

	[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
	private void AnalyzeFunction(
		FunctionUnit functionUnit,
		WarningEmitter warningEmitter)
	{
	}
	}
}
