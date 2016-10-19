﻿using StyleCop;
using StyleCop.CSharp;

namespace StyleCopCustom.Rules
{
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class TabNotBeUseInNonIndent : SourceAnalyzer
	{
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
				if (tokenNode.Previous?.Value.CsTokenType != CsTokenType.EndOfLine &&
					tokenNode.Next?.Value.CsTokenType != CsTokenType.EndOfLine &&
					tokenNode.Value.CsTokenClass == CsTokenClass.Whitespace &&
					tokenNode.Value.Text.Contains("\t"))
				{
					this.Violate(tokenNode.Value);
				}
			}
		}
	}
}
