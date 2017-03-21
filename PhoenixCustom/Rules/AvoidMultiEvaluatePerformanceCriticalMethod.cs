using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using PhoenixCustom.Category;
using Phx;
using Phx.IR;
using Phx.Symbols;

namespace PhoenixCustom
{
	/// <summary>PerformanceCliticalMethodとして指定されたメソッドが複数回使用された場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0007", typeof(DelayedPerformanceCategory))]
	internal sealed class AvoidMultiEvaluatePerformanceCriticalMethod : BasePhoenixCustomRule
	{
		private readonly TypeReference ienumerableTypeReference = TypeReference.GetNamedTypePointerReference(typeof(IEnumerable<>).FullName);

		public AvoidMultiEvaluatePerformanceCriticalMethod(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			var instructionSet = new Dictionary<FunctionSymbol, List<CallInstruction>>();
			foreach (var callInstruction in functionUnit.Instructions.OfType<CallInstruction>())
			{
				var symbol = callInstruction.FunctionSymbol;
				if (symbol.IsCompilerGenerated())
				{
					continue;
				}

				List<CallInstruction> ls;
				if (instructionSet.TryGetValue(symbol, out ls))
				{
					ls.Add(callInstruction);
				}
				else
				{
					var fullNameWithoutGenericParameter = string.Format(
						"{0}.{1}",
						symbol.EnclosingAggregateType.DefinitionType.TypeSymbol.NameString,
						symbol.NameString);

					if (Settings.PerformanceCliticalMethod.Contains(fullNameWithoutGenericParameter))
					{
						instructionSet[symbol] = new List<CallInstruction>() { callInstruction };
					}
				}
			}

			if (!instructionSet.Any())
			{
				return;
			}

			functionUnit.FlowGraph.BuildDominators();
			foreach (var pair in instructionSet)
			{
				for (var i = 0; i < pair.Value.Count; i++)
				{
					for (var j = i + 1; j < pair.Value.Count; j++)
					{
						var item1 = pair.Value[i];
						var item2 = pair.Value[j];

						if (functionUnit.FlowGraph.Dominates(item1.BasicBlock, item2.BasicBlock))
						{
							this.Violate(warningEmitter, item2, pair.Key.Name.NameString, item1.GetLineNumber());
						}
						else if (functionUnit.FlowGraph.Dominates(item2.BasicBlock, item1.BasicBlock))
						{
							this.Violate(warningEmitter, item1, pair.Key.Name.NameString, item2.GetLineNumber());
						}
					}
				}
			}
		}
	}
}
