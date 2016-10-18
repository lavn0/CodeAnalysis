using System.Collections.ObjectModel;
using StyleCop;
using StyleCop.CSharp;
using StyleCopCustom.Settings;

namespace StyleCopCustom.Rules
{
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class SpaceIndentMustNotBeUsed : SourceAnalyzer
	{
		private static readonly ReadOnlyCollection<XPathRule> rules;

		static SpaceIndentMustNotBeUsed()
		{
			rules = StyleCopsettingsReader.Settings.XPathRules;
		}

		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument csdocument = (CsDocument)document;
			if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
			{
				this.CheckSpacing(csdocument.Tokens, false, null);
			}
		}

		private void CheckSpacing(MasterList<CsToken> tokens, bool v, object p)
		{
			for (Node<CsToken> tokenNode = tokens.First; tokenNode != null; tokenNode = tokenNode.Next)
			{
				if (tokenNode.Previous?.Value.CsTokenType == CsTokenType.EndOfLine &&
					tokenNode.Value.CsTokenClass == CsTokenClass.Whitespace)
				{
					var trimedSpace = tokenNode.Value.Text.TrimStart('\t');
					if (trimedSpace.Contains("\t") ||
						trimedSpace.Length >= 4)
					{
						this.Violate(tokenNode.Value);
					}
				}
			}
		}
	}
}
