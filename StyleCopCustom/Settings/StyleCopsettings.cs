using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace StyleCopCustom.Settings
{
	/// <summary>StyleCopカスタムルールの設定記述用クラス</summary>
	[DataContract]
	[DebuggerDisplay("XPathRuleCount={XPathRules.Count}")]
	internal class StyleCopsettings
	{
		[DataMember]
		public ReadOnlyCollection<XPathRule> XPathRules { get; set; }
	}
}
