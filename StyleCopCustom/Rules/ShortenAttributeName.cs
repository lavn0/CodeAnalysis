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
				.Select(a => a.ChildExpressions.First())
				.ToList();

			if (violateTargets != null)
			{
				foreach (var violateTarget in violateTargets)
				{
					string attributeName = violateTarget.ExpressionType == ExpressionType.Literal ? violateTarget.Tokens.Last.Value.Text : (violateTarget as MethodInvocationExpression).Name.Tokens.Last.Value.Text;
					if (attributeName.EndsWith("Attribute"))
					{
						this.Violate(violateTarget);
					}
				}
			}

			return true;
		}
	}
}