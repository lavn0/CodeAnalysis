using Microsoft.FxCop.Sdk;
using System.Collections.Generic;

namespace FxCopCustom.Rules
{
	/// <summary>固定値のみが代入されたローカル値を検出する</summary>
	public class AsignedConstOnly : BaseRule
	{
		private Dictionary<Local, Literal> localsOfLiteral = new Dictionary<Local, Literal>();

		public AsignedConstOnly()
				: base(typeof(AsignedConstOnly).Name)
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
						foreach (var local in this.localsOfLiteral)
						{
							if (local.Value != null &&
								!Microsoft.FxCop.Sdk.RuleUtilities.IsCompilerGenerated(local.Key))
							{
								this.Violate(local.Key, local.Key.Name.Name);
							}
						}

						this.localsOfLiteral.Clear();
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
			if (targetLocal == null)
			{
				return;
			}

			var sourceLiteral = assignment.Source as Literal;
			this.localsOfLiteral[targetLocal] = sourceLiteral;
		}
	}
}
