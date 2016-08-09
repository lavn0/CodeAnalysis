using StyleCop;
using StyleCop.CSharp;
using StyleCopCustom.Settings;
using System.Linq;
using System.Text.RegularExpressions;

namespace StyleCopCustom.Rules
{
	/// <summary>数値の記述において、"0" が一定数以上連続することを禁止するルール</summary>
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class NumberAmoountRule : SourceAnalyzer
	{
		private readonly static int MaxRepeatZeroOnNumber;
		private readonly static string Pattern;
		private static Regex regexPattern;
		private static Regex RegexPattern { get { return regexPattern = regexPattern ?? new Regex(Pattern); } }

		static NumberAmoountRule()
		{
			MaxRepeatZeroOnNumber = StyleCopsettingsReader.Settings.MaxRepeatZeroOnNumber;
			Pattern = string.Format(@"^(?<head>\d\d+)(?<zero>0{{{0}}})+$", MaxRepeatZeroOnNumber);
		}

		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument csdocument = (CsDocument)document;
			if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
			{
				csdocument.WalkDocument(elementCallback, null, expressionCallback);
			}
		}

		private bool elementCallback(CsElement element, CsElement parentElement, object context)
		{
			var method = element as Method;
			if (method != null)
			{
				foreach (var parameter in method.Parameters)
				{
					parameter.DefaultArgument?.WalkExpression(null, expressionCallback);
				}
			}

			return true;
		}

		private bool expressionCallback(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
		{
			var literal = expression as LiteralExpression;
			if (literal != null)
			{
				var match = RegexPattern.Match(literal.Text);
				if (match.Success)
				{
					var suggest = @"""" + match.Groups["head"].Value + " * 1" + string.Join(" * 1", match.Groups["zero"].Captures.OfType<Capture>().Select(c => c.Value)) + @"""";
					this.Violate(parentElement, literal, MaxRepeatZeroOnNumber + 1, literal.Text, suggest);
				}

				return true;
			}

			return true;
		}
	}
}