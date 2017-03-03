using System.Linq;
using Microsoft.VisualStudio.CodeAnalysis.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using Phx;

namespace PhoenixCustom
{
	/// <summary>ローカル変数が使用されずに再代入されている場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0002", typeof(ReliabilityCategory))]
	internal sealed class AvoidReasignLocalWithoutUsed : BasePhoenixCustomRule
	{
		public AvoidReasignLocalWithoutUsed(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			if (functionUnit.FunctionSymbol.IsCompilerGenerated())
			{
				return;
			}

			var instructions = functionUnit.Instructions.ToList();

			foreach (var instruction in instructions)
			{
				if (instruction.SourceOperand == null)
				{
					// 変数定義
					continue;
				}

				if (instruction.DestinationOperand == null ||
					instruction.DestinationOperand?.UseInstruction != null ||
					!functionUnit.SymbolTable.AllSymbols.Contains(instruction.DestinationOperand.Symbol))
				{
					continue;
				}

				var returnedOperands = functionUnit.IsNoReturn()
					? null
					: instructions
						.Where(inst => inst.IsReturn)
						.Select(inst => inst.SourceOperand.DefinitionInstruction.DestinationOperand)
						.ToList();

				var isUsedOnAnyCopiedOperand = EnumerableUtility.Seek(
						instruction,
						inst => inst.SourceOperand?.DefinitionInstruction,
						inst => inst.IsCopy)
					.Select(inst => inst.DestinationOperand)
					.Any(op => op.UseInstruction != null && returnedOperands.Contains(op));

				if (!isUsedOnAnyCopiedOperand)
				{
					this.Violate(warningEmitter, instruction, instruction.DestinationOperand.Symbol);
				}
			}
		}
	}
}