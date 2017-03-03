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
	/// <summary>遅延評価可能な変数が複数回使用された場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0004", typeof(ReliabilityCategory))]
	internal sealed class AvoidMultiEvaluateDelayableLocal : BasePhoenixCustomRule
	{
		private readonly TypeReference ienumerableTypeReference = TypeReference.GetNamedTypePointerReference(typeof(IEnumerable<>).FullName);

		public AvoidMultiEvaluateDelayableLocal(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			var locals = functionUnit.SymbolTable.AllSymbols.OfType<LocalVariableSymbol>().Where(s => !s.IsToolGenerated).ToList();
			var instructionSet = new Dictionary<LocalVariableSymbol, List<CallInstruction>>();
			foreach (var basicBlock in functionUnit.FlowGraph.BasicBlocks)
			{
				foreach (var callInstruction in basicBlock.Instructions.OfType<CallInstruction>())
				{
					foreach (var param in callInstruction.ArgumentsWithParameters)
					{
						if (!this.ienumerableTypeReference.MatchesType(param.ArgumentOperand.Type))
						{
							continue;
						}

						var symbol = param.ArgumentOperand.DefinitionOperand.Symbol?.AsLocalVariableSymbol;
						if (symbol == null)
						{
							continue;
						}

						List<CallInstruction> ls = instructionSet.TryGetValue(symbol, out ls) ? ls : instructionSet[symbol] = new List<CallInstruction>();
						ls.Add(callInstruction);
					}
				}
			}

			if (instructionSet.Any())
			{
				functionUnit.FlowGraph.BuildDominators();
			}

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
