using System.Diagnostics;
using System.Runtime.Serialization;

namespace StyleCopCustom.Settings
{
	[DataContract]
	[DebuggerDisplay("{Name}, {Index}")]
	internal class MethodArgumentInfo
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int Index { get; set; }
	}
}
