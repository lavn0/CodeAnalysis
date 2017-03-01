using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.CodeAnalysis.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using Phx;
using Phx.IR;
using Phx.Symbols;

namespace PhoenixCustom
{
	/// <summary>遅延評価可能な引数が複数回評価された場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0003", typeof(ReliabilityCategory))]
	internal sealed class AvoidMultiEvaluateDelayableParameter : BasePhoenixCustomRule
	{
		public AvoidMultiEvaluateDelayableParameter(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			var counter = new Dictionary<ParameterSymbol, int>();
			foreach (var callInstruction in functionUnit.Instructions.OfType<CallInstruction>())
			{
				foreach (var param in callInstruction.ArgumentsWithParameters)
				{
					var parameterSymbol = param.ArgumentOperand.DefinitionOperand.GetDefinedParameter();
					if (parameterSymbol == null)
					{
						continue;
					}

					int count = 0;
					counter.TryGetValue(parameterSymbol, out count);
					count++;
					counter[parameterSymbol] = count;
					if (count >= 2)
					{
						this.Violate(warningEmitter, callInstruction, count);
					}
				}
			}
		}
	}
}
