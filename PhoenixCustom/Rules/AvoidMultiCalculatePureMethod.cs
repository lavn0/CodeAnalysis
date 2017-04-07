using System.Linq;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using PhoenixCustom.Category;
using PhoenixCustom.Utilities;
using Phx;
using Phx.IR;

namespace PhoenixCustom.Rules
{
	/// <summary>同じ結果になるメソッドが複数回呼び出された場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0009", typeof(DelayedPerformanceCategory))]
	internal sealed class AvoidMultiCalculatePureMethod : BasePhoenixCustomRule
	{
		public AvoidMultiCalculatePureMethod(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			// 条件：あるOperandに対して、
			// 　同じMethodCall
			// 　同じArgumentParameter
			// 　上記が大本もしくはlocal等まで同じ
			var variableOperands = functionUnit.Instructions
				.SelectMany(inst => inst.SourceAndDestinationOperands)
				.Select(op => op.DefinitionOperand)
				.OfType<VariableOperand>()
				.Distinct()
				.Where(vop => vop.DefinitionInstruction.IsCallInstruction)
				.ToList();

			var pairs = variableOperands
				.Select(op => op.DefinitionInstruction)
				.Cast<CallInstruction>()
				.ToList();

			if (!pairs.Any())
			{
				return;
			}

			functionUnit.FlowGraph.BuildDominators();
			for (var i = 0; i < pairs.Count; i++)
			{
				for (var j = i + 1; j < pairs.Count; j++)
				{
					var callInstruction1 = pairs[i];
					var callInstruction2 = pairs[j];

					if (callInstruction1.FunctionSymbol != callInstruction2.FunctionSymbol ||
						callInstruction1.FunctionSymbol.IsPropertyGetter() ||
						callInstruction1.FunctionSymbol.IsConstructor)
					{
						continue;
					}

					var parameterOperands1 = EnumerateArgumentsWithParametersExtensions
						.AsList(callInstruction1.ArgumentsWithParameters)
						.Select(arg => arg.ArgumentOperand.DefinitionOperand);
					var parameterOperands2 = EnumerateArgumentsWithParametersExtensions
						.AsList(callInstruction2.ArgumentsWithParameters)
						.Select(arg => arg.ArgumentOperand.DefinitionOperand);

					if (parameterOperands1.SequenceEqual(parameterOperands2))
					{
						if (functionUnit.FlowGraph.Dominates(callInstruction1.BasicBlock, callInstruction2.BasicBlock))
						{
							this.Violate(warningEmitter, callInstruction2, callInstruction1.GetLineNumber(), callInstruction2.FunctionSymbol.NameString);
						}
						else if (functionUnit.FlowGraph.Dominates(callInstruction2.BasicBlock, callInstruction1.BasicBlock))
						{
							this.Violate(warningEmitter, callInstruction1, callInstruction2.GetLineNumber(), callInstruction1.FunctionSymbol.NameString);
						}
					}
				}
			}
		}
	}
}
