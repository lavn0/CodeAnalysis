using Microsoft.FxCop.Sdk;

namespace FxCopCustom.Rules
{
	/// <summary>System.Linq.Enumerable.Countメソッドの結果が直接比較された場合を検出する</summary>
	public class IgnoreCompareZeroToCountResult : BaseRule
	{
		public IgnoreCompareZeroToCountResult()
			: base(typeof(IgnoreCompareZeroToCountResult).Name)
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

		public override void VisitBinaryExpression(BinaryExpression binaryExpression)
		{
			base.VisitBinaryExpression(binaryExpression);

			if (binaryExpression == null)
			{
				return;
			}

			switch (binaryExpression.NodeType)
			{
				case NodeType.Cgt:
				case NodeType.Clt:
				case NodeType.Ceq:

					var requireViolate =
						RequireViolate(binaryExpression.Operand1) ||
						RequireViolate(binaryExpression.Operand2);

					if (requireViolate)
					{
						var resolutionName = binaryExpression.NodeType == NodeType.Ceq ? "Equals" : "Compare";
						this.Violate(resolutionName, binaryExpression);
					}

					break;
			}
		}

		private static bool RequireViolate(Expression expression)
		{
			var methodCall = expression as MethodCall;
			if (methodCall != null)
			{
				var method = ((MemberBinding)methodCall.Callee).BoundMember as Method;
				if (method.DeclaringType == SystemMembers.EnumerableCount.DeclaringType &&
					method.Template.Name == SystemMembers.EnumerableCount.Name)
				{
					// 対象メソッドの所属クラスとメソッド名がSystem.Linq.Enumerable.Countに一致（ジェネリック型、パラメータは無視して判定）
					return true;
				}
			}

			return false;
		}
	}
}
