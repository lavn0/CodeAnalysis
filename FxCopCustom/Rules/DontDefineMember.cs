using Microsoft.FxCop.Sdk;

namespace FxCopCustom.Rules
{
	/// <summary>定義禁止として設定されたメソッドを検出します。</summary>
	public class DontDefineMember : BaseRule
	{
		public DontDefineMember()
			: base(typeof(DontDefineMember).Name)
		{
		}

		public override ProblemCollection Check(Member member)
		{
			if (member != null)
			{
				switch (member.NodeType)
				{
					case NodeType.Method:
					case NodeType.Property:
					case NodeType.Field:
						foreach (var dontDefineMember in Settings.DontDefimeMember)
						{
							if (dontDefineMember.IsMatch(member))
							{
								this.Violate(member, dontDefineMember.Message);
							}
						}

						break;
				}
			}

			return base.Check(member);
		}
	}
}
