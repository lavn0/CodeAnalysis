using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FxCopCustom.Settings
{
	[DataContract]
	public class MethodInfo
	{
		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public Dictionary<int, string> ParameterType { get; set; }
	}
}
