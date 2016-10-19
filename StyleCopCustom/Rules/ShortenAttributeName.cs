using System.Linq;
using StyleCop;
using StyleCop.CSharp;

namespace StyleCopCustom.Rules
{
	/// <summary>属性を指定する際、属性名末尾の"Attribute"の記述を禁止するルール</summary>
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class ShortenAttributeName : SourceAnalyzer
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
				.Where(a =>
				{
					var attribute = a.ChildExpressions.First();
					return (attribute.ExpressionType == ExpressionType.Literal
						? attribute.Tokens.Last.Value.Text
						: (attribute as MethodInvocationExpression).Name.Tokens.Last.Value.Text)
						.EndsWith("Attribute");
				})
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