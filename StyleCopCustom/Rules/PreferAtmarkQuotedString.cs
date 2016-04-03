using StyleCop;
using StyleCop.CSharp;
using System.Text.RegularExpressions;

namespace StyleCopCustom.Rules
{
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class PreferAtmarkQuotedString : SourceAnalyzer
	{
		const string pattern = @"(?!^.*(?<=(?<!\\)(?:\\\\)*?)\\[^\\].*$)^([""']).*\\\\.*\1$";
		private static Regex regexPattern;
		private static Regex RegexPattern { get { return regexPattern = regexPattern ?? new Regex(pattern); } }

		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument csdocument = (CsDocument)document;
			if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
			{
				csdocument.WalkDocument(null, null, new CodeWalkerExpressionVisitor<object>(this.VistExpression), null);
			}
		}

		private bool VistExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
		{
			var literal = expression as LiteralExpression;
			if (literal != null)
			{
				if (RegexPattern.IsMatch(literal.Text))
				{
					this.Violate(parentElement, literal);
				}
			}

			return true;
		}
	}
}