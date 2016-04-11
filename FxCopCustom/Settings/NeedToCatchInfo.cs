using System.Runtime.Serialization;

namespace FxCopCustom.Settings
{
	[DataContract]
	internal class NeedToCatchInfo
	{
		[DataMember]
		public string MethodFullName { get; set; }

		[DataMember]
		public string ExceptionFullName { get; set; }

		[DataMember]
		public string Message { get; set; }
	}
}
