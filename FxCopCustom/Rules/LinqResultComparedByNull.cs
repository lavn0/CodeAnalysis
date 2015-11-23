using Microsoft.FxCop.Sdk;
using System.Collections.Generic;

namespace FxCopCustom.Rules
{
	/// <summary>LINQのクエリ結果がnullと比較されている場合を検出する</summary>
	public class LinqResultComparedByNull : BaseRule
	{
		private readonly Dictionary<Local, Node> assignmented = new Dictionary<Local, Node>();

		public LinqResultComparedByNull()
				: base(typeof(LinqResultComparedByNull).Name)
		{
		}

		public override ProblemCollection Check(Member member)
		{
			if (member != null)
			{
				switch (member.NodeType)
				{
					case NodeType.Method:
						this.Visit(member);
						break;
				}
			}

			return base.Check(member);
		}

		public override void VisitAssignmentStatement(AssignmentStatement assignment)
		{
			base.VisitAssignmentStatement(assignment);
			if (assignment == null)
			{
				return;
			}

			var targetLocal = assignment.Target as Local;
			if (targetLocal != null)
			{
				this.assignmented[targetLocal] = assignment.Source;
			}
		}

		public override void VisitBinaryExpression(BinaryExpression binaryExpression)
		{
			base.VisitBinaryExpression(binaryExpression);
			if (binaryExpression == null)
			{
				return;
			}

			switch (binaryExpression.NodeType)
			{
				case NodeType.Cgt_Un: // != null比較はコレ
				case NodeType.Cgt: // 一応保険でチェック
				case NodeType.Clt_Un: // 一応保険でチェック
				case NodeType.Clt: // 一応保険でチェック
				case NodeType.Ceq: // 一応保険でチェック
					Local targetLocal = null;
					if (RuleUtilities.IsLiteralForNull(binaryExpression.Operand1))
					{
						targetLocal = binaryExpression.Operand2 as Local;
					}
					else if (RuleUtilities.IsLiteralForNull(binaryExpression.Operand2))
					{
						targetLocal = binaryExpression.Operand1 as Local;
					}

					if (targetLocal != null && this.assignmented.ContainsKey(targetLocal))
					{
						var methodCall = this.assignmented[targetLocal] as MethodCall;
						if (methodCall != null &&
							((MemberBinding)methodCall.Callee).BoundMember.DeclaringType == SystemMembers.Enumerable)
						{
							this.Violate(binaryExpression, targetLocal.Name.Name);
						}
					}

					break;
			}
		}
	}
}
