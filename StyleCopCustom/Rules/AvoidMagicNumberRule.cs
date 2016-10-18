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
		private static ReadOnlyCollection<MethodArgumentInfo> AvoidMagicNumbers { get; }

		static AvoidMagicNumberRule()
		{
			AvoidMagicNumbers = StyleCopsettingsReader.Settings.AvoidMagicNumbers;
		}

		public override void AnalyzeDocument(CodeDocument document)
		{
			CsDocument csdocument = (CsDocument)document;
			if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
			{
				csdocument.WalkDocument(ElementCallback, StatementCallback, ExpressionCallback);
			}
		}

		private bool ElementCallback(CsElement element, CsElement parentElement, object context) => true;

		private bool StatementCallback(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context) => true;

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
						if (string.IsNullOrEmpty(argument.Name?.Text) &&
							argument.Expression.ExpressionType == ExpressionType.Literal)
						{
							var literalExpression = argument.Expression as LiteralExpression;
							if (literalExpression.Token.CsTokenType != CsTokenType.Other &&
								target.Any(t => t.Index == i))
							{
								// 名前付き引数ではなく、固定値
								this.Violate(argument, argument.Expression.Text);
							}
						}
					}
				}
			}

			return true;
		}
	}
}
