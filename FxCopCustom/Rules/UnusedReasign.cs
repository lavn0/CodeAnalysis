using Microsoft.FxCop.Sdk;
using System.Collections.Generic;

namespace FxCopCustom.Rules
{
	/// <summary>参照されずに再設定されたローカル変数を検出する</summary>
	public class UnusedReasign : BaseRule
	{
		private List<AssignmentStatement> statements = new List<AssignmentStatement>();
		private HashSet<Local> initedLocals = new HashSet<Local>();
		private List<Local> locals = new List<Local>();

		public UnusedReasign()
			: base(typeof(UnusedReasign).Name)
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
						this.statements.Clear();
						this.initedLocals.Clear();
						this.locals.Clear();
						break;
				}
			}

			return base.Check(member);
		}

		public override void VisitAssignmentStatement(AssignmentStatement assignment)
		{
			this.statements.Add(assignment);
			base.VisitAssignmentStatement(assignment);

			if (assignment != null)
			{
				var local = assignment.Target as Local;
				if (local != null &&
					!Microsoft.FxCop.Sdk.RuleUtilities.IsCompilerGenerated(local))
				{
					this.locals.Remove(local);
					if (!this.initedLocals.Add(local) &&
						!this.locals.Contains(local))
					{
						this.Violate(assignment);
					}

					this.locals.Clear();
				}
			}
		}

		public override void VisitLocal(Local local)
		{
			this.locals.Add(local);
			base.VisitLocal(local);
		}
	}
}