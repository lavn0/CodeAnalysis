using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace FxCopCustom
{
	/// <summary>FxCopカスタムルールの設定記述用クラス</summary>
	[DataContract]
	internal class FxCopSettings
	{
		[DataMember]
		public ReadOnlyCollection<string> DontUseMethod { get; set; }

		[DataMember]
		public ReadOnlyCollection<MemberInfo> DontDefimeMember { get; set; }
	}
}
