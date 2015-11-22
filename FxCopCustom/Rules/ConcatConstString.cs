using Microsoft.FxCop.Sdk;
using System.Collections.Generic;

namespace FxCopCustom.Rules
{
	/// <summary>固定文字列が再連結されているローカル変数を検出します。</summary>
	public class ConcatConstString : BaseRule
	{
		private Dictionary<Local, Literal> localsOfLiteral = new Dictionary<Local, Literal>();

		public ConcatConstString()
			: base(typeof(ConcatConstString).Name)
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
						this.localsOfLiteral.Clear();
						break;
				}
			}

			return base.Check(member);
		}

		public override void VisitAssignmentStatement(AssignmentStatement assignment)
		{
			try
			{
				if (assignment == null)
				{
					return;
				}

				var targetLocal = assignment.Target as Local;
				if (targetLocal == null)
				{
					return;
				}

				switch (assignment.Source.NodeType)
				{
					case NodeType.Literal:
						this.localsOfLiteral[targetLocal] = assignment.Source as Literal;
						break;

					case NodeType.Call: // MethodCall
						var sourceMethodCall = assignment.Source as MethodCall;
						bool isStringConcatMethodCall = RuleUtilities.IsStringConcatMethodCall(sourceMethodCall);
						if (!isStringConcatMethodCall)
						{
							this.localsOfLiteral.Remove(targetLocal);
							break;
						}

						for (var i = 1; i < sourceMethodCall.Operands.Count; i++)
						{
							// 前連結側のリテラルを算出する
							var prepareLiteral = sourceMethodCall.Operands[i - 1] as Literal;
							if (prepareLiteral == null)
							{
								var prepareLocal = sourceMethodCall.Operands[i - 1] as Local;
								if (prepareLocal != null)
								{
									// ローカル値の場合、処理中に最後に代入されたローカル値を取り出してみる
									this.localsOfLiteral.TryGetValue(prepareLocal, out prepareLiteral);
								}
							}

							if (prepareLiteral == null)
							{
								// 前連結側がリテラル値でなければ終了
								continue;
							}

							var afterLiteral = sourceMethodCall.Operands[i] as Literal;
							if (afterLiteral == null)
							{
								var afterLocal = sourceMethodCall.Operands[i] as Local;
								if (afterLocal != null)
								{
									// ローカル値の場合、処理中に最後に代入されたローカル値を取り出してみる
									this.localsOfLiteral.TryGetValue(afterLocal, out afterLiteral);
								}
							}

							if (afterLiteral == null)
							{
								continue;
							}

							this.Violate(
								assignment,
								prepareLiteral.Value,
								afterLiteral.Value);
						}

						break;

					default:
						this.localsOfLiteral.Remove(targetLocal);
						break;
				}
			}
			finally
			{
				base.VisitAssignmentStatement(assignment);
			}
		}
	}
}
