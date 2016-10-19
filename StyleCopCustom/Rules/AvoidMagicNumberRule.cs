using System.Collections.ObjectModel;
using System.Linq;
using StyleCop;
using StyleCop.CSharp;
using StyleCopCustom.Settings;

namespace StyleCopCustom.Rules
{
	/// <summary>マジックナンバーを使用することを禁止するルール</summary>
	[SourceAnalyzer(typeof(CsParser), "StyleCopCustom.Rules.xml")]
	public class AvoidMagicNumberRule : SourceAnalyzer
	{
		private static readonly ReadOnlyCollection<MethodArgumentInfo> AvoidMagicNumbers;

		static AvoidMagicNumberRule()
		{
			AvoidMagicNumbers = StyleCopsettingsReader.Settings.AvoidMagicNumbers;
		}

		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument csdocument = (CsDocument)document;
			if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
			{
				csdocument.WalkDocument(delegate { return true; }, delegate { return true; }, this.ExpressionCallback);
			}
		}

		private bool ExpressionCallback(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
		{
			if (expression.ExpressionType == ExpressionType.MethodInvocation)
			{
				var methodInvocation = expression as MethodInvocationExpression;
				var target = AvoidMagicNumbers.Where(a => a.Name == methodInvocation.Name.Text).ToList();

				if (target.Any())
				{
					for (int i = 0; i < methodInvocation.Arguments.Count; i++)
					{
						var argument = methodInvocation.Arguments[i];
						if (string.IsNullOrEmpty(argument.Name?.Text) && target.Any(t => t.Index == i))
						{
							switch (argument.Expression.ExpressionType)
							{
								case ExpressionType.Literal:
									var literalExpression = argument.Expression as LiteralExpression;
									if (literalExpression.Token.CsTokenType != CsTokenType.Other)
									{
										// 名前付き引数ではなく、固定値
										this.Violate(argument, argument.Expression.Text);
									}

									break;

								case ExpressionType.Arithmetic:
								case ExpressionType.Logical:
								case ExpressionType.ConditionalLogical:
									if (this.IsHierarchicalLiteralResult(argument.Expression))
									{
										// 名前付き引数ではなく次のいずれかの複合
										// ・固定値同士の計算式(ArithmeticExpression)
										// ・固定値の & や | 演算子による結果(LogicalExpression)
										// ・固定値の && や || 演算子による結果(ConditionalLogicalExpression)
										this.Violate(argument, argument.Expression.Text);
									}

									break;
							}
						}
					}
				}
			}

			return true;
		}

		private bool IsHierarchicalLiteralResult(Expression expression)
		{
			return expression.ChildExpressions.All(ex => (ex.ExpressionType == ExpressionType.Literal && ((LiteralExpression)ex).Token.CsTokenType != CsTokenType.Other) || ((ex is ArithmeticExpression || ex is LogicalExpression || ex is ConditionalLogicalExpression) && this.IsHierarchicalLiteralResult(ex)));
		}
	}
}
