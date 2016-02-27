using Microsoft.FxCop.Sdk;

namespace FxCopCustom.Rules
{
	public class StaticMethodShouldNotCallDateTimeNow : BaseRule
	{
		public StaticMethodShouldNotCallDateTimeNow()
				: base(typeof(StaticMethodShouldNotCallDateTimeNow).Name)
		{
		}

		public override ProblemCollection Check(Member member)
		{
			switch (member.NodeType)
			{
				case NodeType.Method:
					this.Visit(member);
					break;
			}

			return this.Problems;
		}

		public override void VisitMethodCall(MethodCall call)
		{
			MemberBinding mb = call.Callee as MemberBinding;
			if (mb == null)
			{
				return;
			}

			Method method = mb.BoundMember as Method;
			if (method == null || !method.IsStatic)
			{
				return;
			}

			if (method.DeclaringMember == SystemMembers.DateTimeNow)
			{
				Problems.Add(new Problem(GetResolution()));
			}

			base.VisitMethodCall(call);
		}
	}
}
