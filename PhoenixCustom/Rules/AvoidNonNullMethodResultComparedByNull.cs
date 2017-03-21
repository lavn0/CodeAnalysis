using System.Linq;
using Microsoft.VisualStudio.CodeAnalysis.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using Phx;
using Phx.IR;

namespace PhoenixCustom.Rules
{
	/// <summary>戻り値がnullではないメソッドの結果がnullと比較された場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0001", typeof(ReliabilityCategory))]
	internal sealed class AvoidNonNullMethodResultComparedByNull : BasePhoenixCustomRule
	{
		public AvoidNonNullMethodResultComparedByNull(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			foreach (var compareInstruction in functionUnit.Instructions.OfType<CompareInstruction>())
			{
				if (compareInstruction.GetFileName().IsNull)
				{
					// ラムダ式などから生成されたメソッドで対応コードが無い部分の場合
					continue;
				}

				var targetOperand =
					compareInstruction.SourceOperand2.IsNullPtr() ? compareInstruction.SourceOperand1 :
					compareInstruction.SourceOperand1.IsNullPtr() ? compareInstruction.SourceOperand2 : null;
				var functionSymbol = targetOperand?.DefinitionInstruction.SourceOperand?.AsFunctionOperand?.FunctionSymbol;
				if (functionSymbol == null)
				{
					continue;
				}

				var symbol = functionSymbol.UninstantiatedFunctionSymbol ?? functionSymbol;
				var fullNameWithoutGenericParameter = string.Format(
					"{0}.{1}",
					symbol.EnclosingAggregateType.DefinitionType.TypeSymbol.NameString,
					symbol.NameString);

				if (Settings.UnNullReturnMethod.Contains(fullNameWithoutGenericParameter))
				{
					this.Violate(warningEmitter, compareInstruction, symbol);
				}
			}
		}
	}
}
