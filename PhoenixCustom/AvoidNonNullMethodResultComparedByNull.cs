using Microsoft.VisualStudio.CodeAnalysis.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using Phx;
using Phx.IR;
using System.Linq;

namespace PhoenixCustom
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
			var comps = functionUnit.Instructions.OfType<CompareInstruction>().ToList();

			foreach (var comp in comps)
			{
				var functionSymbol =
					comp.SourceOperand2.IsNullPtr()
						? comp.SourceOperand1.DefinitionInstruction.SourceOperand?.AsFunctionOperand?.FunctionSymbol
					: comp.SourceOperand1.IsNullPtr()
						? comp.SourceOperand2.DefinitionInstruction.SourceOperand?.AsFunctionOperand?.FunctionSymbol
						: null;

				if (functionSymbol == null)
				{
					continue;
				}

				var fullNameWithoutGenericParameter = string.Format(
					"{0}.{1}",
					functionSymbol.EnclosingAggregateType.DefinitionType.TypeSymbol.NameString,
					functionSymbol.UninstantiatedFunctionSymbol.NameString);

				if (this.settings.UnNullReturnMethod.Contains(fullNameWithoutGenericParameter))
				{
					this.Violate(warningEmitter, comp);
				}
			}
		}
	}
}
