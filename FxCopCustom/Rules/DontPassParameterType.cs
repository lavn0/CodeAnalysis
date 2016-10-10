using System.Linq;
using Microsoft.FxCop.Sdk;

namespace FxCopCustom.Rules
{
	/// <summary>メソッドに渡すことが禁止された型のパラメータを検出します。</summary>
	public class DontPassParameterType : BaseRule
	{
		public DontPassParameterType()
			: base(typeof(DontPassParameterType).Name)
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
				foreach (var dontPassParameterType in Settings.DontPassParameterType)
				{
					if (dontPassParameterType.FullName == method.FullName)
					{
						var infos = Enumerable.Range(1, method.Parameters.Count).GroupJoin(
							dontPassParameterType.ParameterType,
							index => index,
							info => info.Key,
							(index, info) => info.FirstOrDefault(i => i.Key == index).Value)
							.ToList();

						for (var index = 0; index < method.Parameters.Count; index++)
						{
							string value;
							if (dontPassParameterType.ParameterType.TryGetValue(index + 1, out value))
							{
								if (call.Operands[index].Type.FullName == value)
								{
									this.Violate(call, method.FullName, index + 1, value);
								}
							}
						}
					}
				}
			}

			base.VisitMethodCall(call);
		}
	}
}
