using StyleCop;
using StyleCop.CSharp;

namespace StyleCopCustom
{
	public static class SourceAnalyzerUtility
	{
		internal static void Violate(this SourceAnalyzer sourceAnalyzer, CsElement elemnet, CodeUnit codeUnit)
		{
			sourceAnalyzer.AddViolation(elemnet, codeUnit.Location, sourceAnalyzer.GetType().Name);
		}
	}
}
