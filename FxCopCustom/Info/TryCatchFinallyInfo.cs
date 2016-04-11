using Microsoft.FxCop.Sdk;
using System.Collections.Generic;
using System.Linq;

namespace FxCopCustom.Info
{
	/// <summary>try/catch/finallyの組み合わせを表現したクラス</summary>
	internal class TryCatchFinallyInfo
	{
		private TryCatchFinallyInfo()
		{
		}

		/// <summary>try句に含まれるInstruction</summary>
		public List<Instruction> TryInstruction { get; set; }

		/// <summary>catch句に含まれるInstruction</summary>
		public List<List<Instruction>> CatchInstructions { get; set; }

		/// <summary>finally句に含まれるInstruction</summary>
		public List<Instruction> FinallyInstruction { get; set; }

		internal static List<TryCatchFinallyInfo> GetTryInfos(List<Instruction> instructions)
		{
			var tryinfos = new List<TryCatchFinallyInfo>();
			TryCatchFinallyInfo lastTryInfo = null;

			for (var i = 0; i < instructions.Count; i++)
			{
				var inst = instructions[i];
				var partInstructions = instructions
					.SkipWhile(e => e != inst.Value)
					.TakeUntil(e => e != inst).ToList();

				switch (inst.OpCode)
				{
					case OpCode._EndTry:
						tryinfos.Add(lastTryInfo = new TryCatchFinallyInfo() { TryInstruction = partInstructions });
						break;

					case OpCode._EndHandler:
						switch ((inst.Value as Instruction).OpCode)
						{
							case OpCode._Catch:
								(lastTryInfo.CatchInstructions ?? (lastTryInfo.CatchInstructions = new List<List<Instruction>>())).Add(partInstructions);
								break;

							case OpCode._Finally:
								lastTryInfo.FinallyInstruction = partInstructions;
								break;
						}

						break;
				}
			}

			return tryinfos;
		}
	}
}
