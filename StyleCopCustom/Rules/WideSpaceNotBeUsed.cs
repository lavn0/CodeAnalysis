using System.Collections.ObjectModel;
using StyleCop;
using StyleCop.CSharp;
using StyleCopCustom.Settings;

namespace StyleCopCustom.Rules
{
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class WideSpaceNotBeUsed : SourceAnalyzer
	{
		private static readonly ReadOnlyCollection<XPathRule> rules;

		static WideSpaceNotBeUsed()
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
				if (tokenNode.Value.CsTokenClass == CsTokenClass.Whitespace &&
					tokenNode.Value.Text.Contains("　"))
				{
					this.Violate(tokenNode.Value);
				}
			}
		}
	}
}
