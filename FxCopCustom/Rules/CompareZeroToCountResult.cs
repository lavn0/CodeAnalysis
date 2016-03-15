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
			if (IsUnEnumerableCountMethodCall(binaryExpression.Operand1))
			{
				var literal = binaryExpression.Operand2 as Literal;
				var compareValue = (int?)literal?.Value;
				if (compareValue > 0)
				{
					switch (binaryExpression.NodeType)
					{
						case NodeType.Ceq:
							if ((((binaryExpression.Operand1 as MethodCall)?.Operands.SingleOrDefault() as MethodCall)?.Callee as MemberBinding)?.BoundMember.Name.Name != "Take<System.Object>")
							{
								this.Violate("TakeCount", binaryExpression);
							}

							return;

						case NodeType.Cgt:
						case NodeType.Cgt_Un:
							this.Violate("SkipAny", binaryExpression);
							return;

						case NodeType.Clt:
						case NodeType.Clt_Un:
							if (compareValue == 1)
							{
								this.Violate("Any", binaryExpression);
							}
							else
							{
								this.Violate("TakeCount", binaryExpression);
							}

							return;
					}

				}
				else if (compareValue == 0)
				{
					switch (binaryExpression.NodeType)
					{
						case NodeType.Ceq:
						case NodeType.Cgt:
						case NodeType.Cgt_Un:
							if ((((binaryExpression.Operand1 as MethodCall)?.Operands.SingleOrDefault() as MethodCall)?.Callee as MemberBinding)?.BoundMember.Name.Name != "Take<System.Object>")
							{
								this.Violate("Any", binaryExpression);
							}

							return;

						case NodeType.Clt:
						case NodeType.Clt_Un:
							this.Violate("Error", binaryExpression);
							return;
					}
				}
				else
				{
					this.Violate("Error", binaryExpression);
					return;
				}
			}
			else if (IsUnEnumerableCountMethodCall(binaryExpression.Operand2))
			{
				var compareValue = (binaryExpression.Operand1 as Literal)?.Value as int?;
				if (compareValue > 0)
				{
					switch (binaryExpression.NodeType)
					{
						case NodeType.Ceq:
							this.Violate("TakeCount", binaryExpression);
							return;

						case NodeType.Cgt:
						case NodeType.Cgt_Un:
							this.Violate("Any", binaryExpression);
							return;

						case NodeType.Clt:
						case NodeType.Clt_Un:
							this.Violate("SkipAny", binaryExpression);
							return;
					}

				}
				else if (compareValue == 0)
				{
					switch (binaryExpression.NodeType)
					{
						case NodeType.Ceq:
						case NodeType.Cgt:
						case NodeType.Cgt_Un:
							this.Violate("Error", binaryExpression);
							return;

						case NodeType.Clt:
						case NodeType.Clt_Un:
							this.Violate("Any", binaryExpression);
							return;
					}
				}
				else
				{
					this.Violate("Error", binaryExpression);
				}
			}

			base.VisitBinaryExpression(binaryExpression);
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
