using System.Collections.Generic;
using System.Linq;

namespace StyleCopCustomUnitTest.Resources
{
	// Test
	public static class PreferAtmarkQuotedStringTestClass
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

		/// <summary>
		/// 1行コメントの説明
		/// </summary>
		public string NG1 { get; }

		/// <summary>
		/// 複数コメントの説明
		/// </summary>
		public string NG2 { get; }

		/// <summary>
		/// 複数コメントの
		/// 説明
		/// </summary>
		public string NG3 { get; }
	}
}
