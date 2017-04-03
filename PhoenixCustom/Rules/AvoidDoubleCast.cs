using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using PhoenixCustom.Category;
using Phx;
using Phx.IR;

namespace PhoenixCustom.Rules
{
	/// <summary>複数回キャストされた場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0008", typeof(DelayedPerformanceCategory))]
	internal sealed class AvoidDoubleCast : BasePhoenixCustomRule
	{
		private readonly TypeReference ienumerableTypeReference = TypeReference.GetNamedTypePointerReference(typeof(IEnumerable<>).FullName);

		public AvoidDoubleCast(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			var instructionSet = new Dictionary<Operand, List<ValueInstruction>>();
			foreach (var valueInstruction in functionUnit.Instructions.OfType<ValueInstruction>())
			{
				if (!OpCodes.Castclass.Name.Equals(valueInstruction.OpcodeToString(), StringComparison.InvariantCultureIgnoreCase))
				{
					continue;
				}

				var operand = valueInstruction.SourceOperand2.DefinitionOperand;
				List<ValueInstruction> ls = instructionSet.TryGetValue(operand, out ls) ? ls : instructionSet[operand] = new List<ValueInstruction>();
				ls.Add(valueInstruction);
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
							this.Violate(warningEmitter, item2, item1.GetLineNumber());
						}
						else if (functionUnit.FlowGraph.Dominates(item2.BasicBlock, item1.BasicBlock))
						{
							this.Violate(warningEmitter, item1, item2.GetLineNumber());
						}
					}
				}
			}
		}
	}
}
