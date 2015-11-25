using Microsoft.FxCop.Sdk;
using System.Linq;

namespace FxCopCustom.Rules
{
	/// <summary><see cref="System.Linq.Enumerable.Count{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>メソッドの結果が直接比較された場合を検出する</summary>
	public class CompareZeroToCountResult : BaseRule
	{
		public CompareZeroToCountResult()
			: base(typeof(CompareZeroToCountResult).Name)
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
			if (binaryExpression.NodeType == NodeType.Ceq)
			{
				var binaryExpression1 = binaryExpression.Operand1 as BinaryExpression;
				if (binaryExpression1 != null)
				{
					var resolutionName = Validate(binaryExpression1, false);
					if (!string.IsNullOrEmpty(resolutionName))
					{
						this.Violate(resolutionName, binaryExpression);
					}

					return;
				}
			}

			{
				var resolutionName = Validate(binaryExpression, false);
				if (!string.IsNullOrEmpty(resolutionName))
				{
					this.Violate(resolutionName, binaryExpression);
					return;
				}
			}

			base.VisitBinaryExpression(binaryExpression);
		}

		private static string Validate(BinaryExpression binaryExpression, bool withCeq)
		{
			if (binaryExpression == null)
			{
				return null;
			}

			switch (binaryExpression.NodeType)
			{
				case NodeType.Cgt:
				case NodeType.Clt:
				case NodeType.Ceq:

					if (IsUnEnumerableCountMethodCall(binaryExpression.Operand1))
					{
						var compareValue = (binaryExpression.Operand2 as Literal)?.Value as int?;
						if (compareValue == null)
						{
							return "Take";
						}

						var resolutioonName =
							compareValue == 0 && ((binaryExpression.NodeType == NodeType.Clt && !withCeq) || (binaryExpression.NodeType == NodeType.Cgt && withCeq))
							? "Error"
							: compareValue == 0 && ((binaryExpression.NodeType == NodeType.Ceq && !withCeq) || (binaryExpression.NodeType == NodeType.Clt && withCeq) || (binaryExpression.NodeType == NodeType.Cgt && !withCeq)) ||
							  compareValue == 1 && binaryExpression.NodeType == NodeType.Clt && !withCeq
								? "Any"
								: "Take";
						return resolutioonName;
					}

					break;
			}

			return null;
		}

		/// <summary><see cref="System.Linq.Enumerable.Count{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>の呼び出しか判定する</summary>
		/// <param name="expression">判定対象</param>
		/// <returns><see cref="System.Linq.Enumerable.Count{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>の呼び出しである場合、true</returns>
		private static bool IsUnEnumerableCountMethodCall(Expression expression)
		{
			var methodCall = expression as MethodCall;
			if (methodCall != null)
			{
				var method = ((MemberBinding)methodCall.Callee).BoundMember as Method;
				if (method.DeclaringType == SystemMembers.EnumerableCount.DeclaringType &&
					method.Template.Name == SystemMembers.EnumerableCount.Name)
				{
					// 対象メソッドの所属クラスとメソッド名がSystem.Linq.Enumerable.Countに一致（ジェネリック型、パラメータは無視して判定）

					var callSourceType = methodCall.Operands[0].Type; // Enumerable.Countメソッドを呼び出したインスタンスの型
					if (!callSourceType.Members.Any(
						m =>
						{
							var name = m.Name.Name;
							return name == "Count" || name == "Length";
						}))
					{
						// CountまたはLengthプロパティが存在しない型のインスタンスからSystem.Linq.Enumerable.Countメソッドが呼び出されている
						return true;
					}
				}
			}

			return false;
		}
	}
}
