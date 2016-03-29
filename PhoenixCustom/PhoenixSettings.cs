using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace PhoenixCustom
{
	/// <summary>Phoenixカスタムルールの設定記述用クラス</summary>
	[DataContract]
	internal class PhoenixSettings
	{
		[DataMember]
		public ReadOnlyCollection<string> UnNullReturnMethod { get; set; }
	}
}
