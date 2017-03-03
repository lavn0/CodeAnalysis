using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Utilities;
using PhoenixCustom.Category;
using Phx;
using Phx.IR;

namespace PhoenixCustom
{
	/// <summary>IEnumerable&lt;T&gt;型を返却するメソッドが遅延評価可能なインスタンスを返却しない場合を検出する</summary>
	[LocalizedFxCopRule("PhenixCustom.PH0005", typeof(DelayedPerformanceCategory))]
	internal sealed class EnumerateMethodShouldBeDelayed : BasePhoenixCustomRule
	{
		private readonly TypeReference ienumerableTypeReference = TypeReference.GetNamedTypePointerReference(typeof(IEnumerable<>).FullName);

		public EnumerateMethodShouldBeDelayed(StatisticsService statisticsService)
			: base(statisticsService)
		{
		}

		[FunctionUnitTask(FunctionUnitTargetState.Dataflow)]
		private void AnalyzeFunction(
			FunctionUnit functionUnit,
			WarningEmitter warningEmitter)
		{
			if (functionUnit.FunctionSymbol.IsCompilerGenerated() ||
				!ienumerableTypeReference.MatchesType(functionUnit.FunctionSymbol.FunctionType.ReturnType))
			{
				return;
			}

			if (functionUnit.FunctionSymbol.AttributeSymbolList != null)
			{
				foreach (Phx.Symbols.AttributeSymbol att in functionUnit.FunctionSymbol.AttributeSymbolList)
				{
					if (att.NameString == typeof(IteratorStateMachineAttribute).FullName)
					{
						return;
					}
				}
			}

			var nonIEnumerableReturnInstrutions = functionUnit.Instructions
				.OfType<BranchInstruction>()
				.Where(i => i.IsReturn && !TypeReference.GenericIEnumerable.MatchesType(i.SourceOperand.Type))
				.ToList();
			foreach (var instruction in nonIEnumerableReturnInstrutions)
			{
				this.Violate(warningEmitter, instruction);
			}
		}
	}
}
