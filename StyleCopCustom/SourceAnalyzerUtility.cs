using StyleCop;
using StyleCop.CSharp;
using System.Diagnostics;
using System.Linq;

namespace StyleCopCustom
{
	public static class SourceAnalyzerUtility
	{
		internal static void Violate(this SourceAnalyzer sourceAnalyzer, CsElement element, CodeUnit codeUnit)
		{
			sourceAnalyzer.AddViolation(element, codeUnit.Location, sourceAnalyzer.GetType().Name);
			DebugWrite(element.Violations.Last());
		}

		[Conditional("DEBUG")]
		private static void DebugWrite(Violation violation, params object[] args)
		{
			Debug.WriteLine(
				"{0} ({1}): {2}",
				violation.SourceCode.Path,
				violation.Line,
				string.Format(violation.Message, args));
		}
	}
}
