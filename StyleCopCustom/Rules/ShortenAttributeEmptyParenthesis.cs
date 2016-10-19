using System.Linq;
using StyleCop;
using StyleCop.CSharp;

namespace StyleCopCustom.Rules
{
	/// <summary>属性を指定する際、空の括弧を省略するルール</summary>
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class ShortenAttributeEmptyParenthesis : SourceAnalyzer
	{
		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument csdocument = (CsDocument)document;
			if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
			{
				csdocument.WalkDocument(elementCallback);
			}
		}

		private bool elementCallback(CsElement element, CsElement parentElement, object context)
		{
			var violateTargets = element.Attributes?
				.SelectMany(a => a.AttributeExpressions)
				.Select(a => a.ChildExpressions.First())
				.OfType<MethodInvocationExpression>()
				.Where(a => !a.Arguments.Any())
				.ToList();

			if (violateTargets != null)
			{
				foreach (var violateTarget in violateTargets)
				{
					this.Violate(violateTarget);
				}
			}

			return true;
		}
	}
}