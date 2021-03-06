﻿using System.Diagnostics;
using System.Linq;
using StyleCop;
using StyleCop.CSharp;

namespace StyleCopCustom
{
	public static class SourceAnalyzerUtility
	{
		internal static void Violate(this SourceAnalyzer sourceAnalyzer, CsElement element, CodeUnit codeUnit, params object[] args)
		{
			Violate(sourceAnalyzer, element, codeUnit.Location, args);
		}

		internal static void Violate(this SourceAnalyzer sourceAnalyzer, CsElement element, CodeLocation location, params object[] args)
		{
			var ruleName = sourceAnalyzer.GetType().Name;
			var rule = sourceAnalyzer.GetRule(ruleName);
			if (rule != null)
			{
				sourceAnalyzer.AddViolation(element, location, ruleName, args);
				DebugWrite(element.Violations.Last());
			}
		}

		internal static void Violate(this SourceAnalyzer sourceAnalyzer, ICodePart value, params object[] args)
		{
			var ruleName = sourceAnalyzer.GetType().Name;
			var rule = sourceAnalyzer.GetRule(ruleName);
			if (rule != null)
			{
				var element = value.FindParentElement();
				sourceAnalyzer.AddViolation(element, value.Location, ruleName, args);
				DebugWrite(element.Violations.Last());
			}
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
