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
		[DataMember(Order = 1)]
		public int MaxRepeatZeroOnNumber { get; set; }

		[DataMember(Order = 2)]
		public ReadOnlyCollection<XPathRule> XPathRules { get; set; }

		[DataMember(Order = 3)]
		public ReadOnlyCollection<MethodArgumentInfo> AvoidMagicNumbers { get; internal set; }
	}
}
