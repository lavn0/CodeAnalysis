using StyleCop;
using StyleCop.CSharp;
using StyleCopCustom.Settings;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace StyleCopCustom.Rules
{
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class XmlCommentRule : SourceAnalyzer
	{
		private static readonly ReadOnlyCollection<XPathRule> rules;

		static XmlCommentRule()
		{
			rules = StyleCopsettingsReader.Settings.XPathRules;
		}

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
			if (element.Header != null)
			{
				XDocument xml;
				try
				{
					var xmlText = string.Format("<root>{0}</root>", element.Header.RawText);
					xml = XDocument.Parse(xmlText, LoadOptions.PreserveWhitespace); // Header.Text / Header.RawText の違いを気にしていない
				}
				catch
				{
					return true; // XMLコメントの形式ミスはこのルールで検出しない
				}

				foreach (var xpathRule in rules)
				{
					if (xml.XPathEvaluate<XObject>(xpathRule.XPath).Any())
					{
						this.Violate(element, element.Header.Location, xpathRule.Message);
					}
				}
			}

			return true;
		}
	}
}