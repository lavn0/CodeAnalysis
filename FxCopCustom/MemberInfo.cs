using FxCopCustom.Extention;
using Microsoft.FxCop.Sdk;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace FxCopCustom
{
	[DataContract]
	internal class MemberInfo
	{
		[DataMember]
		public bool? IsStatic { get; set; }

		[DataMember]
		public bool? IsPublic { get; set; }

		[DataMember]
		public bool? IsPrivate { get; set; }

		[DataMember]
		public string TypeName { get; set; }

		[DataMember]
		public string RegexTypeName { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string RegexName { get; set; }

		[DataMember]
		public string Message { get; set; }

		public bool IsMatch(Member member)
		{
			return
				(!this.IsStatic.HasValue || this.IsStatic.Value == member.IsStatic) &&
				(!this.IsPublic.HasValue || this.IsPublic.Value == member.IsPublic) &&
				(!this.IsPrivate.HasValue || this.IsPrivate.Value == member.IsPrivate) &&
				(string.IsNullOrEmpty(this.TypeName) || this.TypeName == (member as Method)?.ReturnType.Name.Name) &&
				(this.RegexTypeName == null || Regex.IsMatch(member.GetDefinedType().FullName, this.RegexTypeName)) &&
				(string.IsNullOrEmpty(this.Name) || this.Name == member.Name.Name) &&
				(this.RegexName == null || Regex.IsMatch(member.Name.Name, this.RegexName));
		}
	}
}
