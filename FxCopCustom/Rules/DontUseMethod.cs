using Microsoft.FxCop.Sdk;

namespace FxCopCustom.Rules
{
	/// <summary>使用禁止として設定されたメソッドを検出します。</summary>
	public class DontUseMethod : BaseRule
	{
		public DontUseMethod()
			: base(typeof(DontUseMethod).Name)
		{
		}

		public override ProblemCollection Check(Member member)
		{
			if (member != null)
			{
				switch (member.NodeType)
				{
					case NodeType.Method:
					case NodeType.Property:
						this.Visit(member);
						break;
				}
			}

			return base.Check(member);
		}

		public override void VisitMethodCall(MethodCall call)
		{
			var memberBinding = (MemberBinding)call.Callee;
			var member = memberBinding.BoundMember;
			if (member.NodeType == NodeType.Method)
			{
				var method = (Method)member;
				if (settings.DontUseMethod.Contains(method.FullName))
				{
					this.Violate(call, method.FullName);
				}
			}

			base.VisitMethodCall(call);
		}
	}
}
