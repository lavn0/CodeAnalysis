using System.Diagnostics;
using System.Runtime.Serialization;

namespace StyleCopCustom.Settings
{
	[DataContract]
	[DebuggerDisplay("{XPath}, {Message}")]
	internal class XPathRule
	{
		[DataMember]
		public string XPath { get; set; }

		[DataMember]
		public string Message { get; set; }
	}
}
