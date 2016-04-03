using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace StyleCopCustom.Settings
{
	/// <summary>StyleCopカスタムルールの設定記述用クラス</summary>
	internal static class StyleCopsettingsReader
	{
		private const string settingFileName = "StyleCopSettings.json";

		public static StyleCopsettings Settings { get; }

		static StyleCopsettingsReader()
		{
			// BOMを読み込むためにStreamReaderで読み込み、ReadObjectメソッド引き数に使えるようにするためにMemoryStreamに転写する
			using (var sr = new StreamReader(settingFileName))
			using (var str = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
			{
				var serializer = new DataContractJsonSerializer(typeof(StyleCopsettings));
				Settings = (StyleCopsettings)serializer.ReadObject(str);
			}
		}
	}
}
