using System.Collections.Generic;
using System.Linq;

namespace ViolationLibrary
{
	public static class LinqResultComparedByNullTest
	{
		public static List<string> GetSample()
		{
			return new List<string>() { "1", "2", "3" };
		}

		public static bool NG1()
		{
			var sequence = GetSample().Where(e => e is string);
			if (sequence != null)
			{
				return sequence.Any();
			}

			return false;
		}

		public static bool NG2()
		{
			var sequence = GetSample().Where(e => e is string);
			if (null != sequence)
			{
				return sequence.Any();
			}

			return false;
		}

		public static bool OK1()
		{
			var sequence = GetSample().Where(e => e is string);
			return sequence.Any();
		}
	}
}
