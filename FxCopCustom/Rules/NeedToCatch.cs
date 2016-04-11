using FxCopCustom.Info;
using Microsoft.FxCop.Sdk;
using System.Linq;

namespace FxCopCustom.Rules
{
	public class NeedToCatch : BaseRule
	{
		public NeedToCatch()
			: base(typeof(NeedToCatch).Name)
		{
		}

		public override ProblemCollection Check(Member member)
		{
			if (Settings.NeedToCatchInfos.Any())
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

		public override void VisitMethod(Method method)
		{
			var instructions = method.Instructions.ToList();
			var tryInfos = TryCatchFinallyInfo.GetTryInfos(instructions);

			foreach (var info in Settings.NeedToCatchInfos)
			{
				var targetInstructions = instructions
					.Where(i =>
					{
						switch (i.OpCode)
						{
							case OpCode.Call:
							case OpCode.Calli:
							case OpCode.Callvirt:
								return (i.Value as Method).FullName == info.MethodFullName;
						}

						return false;
					}).ToList();

				foreach (var targetInstruction in targetInstructions)
				{
					if (tryInfos.Any())
					{
						foreach (var tryInfo in tryInfos)
						{
							if (!tryInfo.TryInstruction.Contains(targetInstruction) ||
								tryInfo.CatchInstructions == null ||
								tryInfo.CatchInstructions.All(insts => (insts[0].Value as ClassNode).FullName != info.ExceptionFullName))
							{
								this.Violate(targetInstruction, info.Message);
							}
						}
					}
					else
					{
						this.Violate(targetInstruction, info.Message);
					}
				}
			}

			base.VisitMethod(method);
		}
	}
}
