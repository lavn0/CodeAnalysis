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
		/// <summary>リテラル値で許可する "0" の連続数</summary>
		[DataMember]
		public int MaxRepeatZeroOnNumber { get; set; }

		[DataMember]
		public ReadOnlyCollection<XPathRule> XPathRules { get; set; }
	}
}
