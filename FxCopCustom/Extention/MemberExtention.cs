using Microsoft.FxCop.Sdk;

namespace FxCopCustom.Extention
{
	public static class MemberExtention
	{
		public static TypeNode GetDefinedType(this Member member)
		{
			switch (member.NodeType)
			{
				case NodeType.Method: return ((Method)member).ReturnType;
				case NodeType.Field: return ((Field)member).Type;
				case NodeType.Property: return ((PropertyNode)member).Type;
			}

			return null;
		}
	}
}
