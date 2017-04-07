using System.Collections.Generic;
using Phx.IR;

namespace PhoenixCustom.Utilities
{
	public static class EnumerateArgumentsWithParametersExtensions
	{
		public static IList<ArgumentWithParameter> AsList(EnumerateArgumentsWithParameters parameters)
		{
			var results = new List<ArgumentWithParameter>();
			foreach (var parameter in parameters)
			{
				results.Add(parameter);
			}

			return results;
		}
	}
}
