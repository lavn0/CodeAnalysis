using Microsoft.FxCop.Sdk;
using System;

namespace FxCopCustom
{
	public static class RuleUtilities
	{
		public static bool IsStringConcatMethodCall(MethodCall sourceMethodCall)
		{
			if (sourceMethodCall == null)
			{
				return false;
			}

			var boundMember = ((MemberBinding)sourceMethodCall.Callee).BoundMember;
			var isStringConcatMethodCall = boundMember.FullName.StartsWith("System.String.Concat(", StringComparison.OrdinalIgnoreCase);
			return isStringConcatMethodCall;
		}

		public static bool IsLiteralForNull(Node node)
		{
			if (node == null ||
				node.NodeType != NodeType.Literal)
			{
				return false;
			}

			var literal = node as Literal;
			return literal.Value == null;
		}
	}
}
