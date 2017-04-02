namespace StyleCopCustomUnitTest.Resources
{
	// Test
	public class XmlCommentRuleTestClass
	{
		/// <summary>1行コメントの説明</summary>
		public string OK1 { get; }

		/// <summary>複数コメントの
		/// 説明</summary>
		public string OK2 { get; }

		/// <summary>複数コメントの
		/// 説明
		/// </summary>
		public string OK3 { get; }

		/// <summary>正しくないXMLコメント<summary>
		public string OK4 { get; }

		// ERROR(3) 開始タグ直後開始ではないコメント
		/// <summary>
		/// 1行コメントの説明
		/// </summary>
		public string NG1 { get; }

		// ERROR(3) 開始タグ直後開始ではないコメント
		/// <summary>
		/// 複数コメントの説明
		/// </summary>
		public string NG2 { get; }

		// ERROR(3) 開始タグ直後開始ではないコメント
		/// <summary>
		/// 複数コメントの
		/// 説明
		/// </summary>
		public string NG3 { get; }
	}
}
