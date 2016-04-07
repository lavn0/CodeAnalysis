using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class EnumerableUtility
{
	[DebuggerStepThrough]
	public static IEnumerable<T> Seek<T>(T seed, Func<T, T> iterator)
	{
		for (T item = seed; item != null; item = iterator(item))
		{
			yield return item;
		}
	}

	[DebuggerStepThrough]
	public static IEnumerable<T> Seek<T>(T seed, Func<T, T> iterator, Func<T, bool> continues)
	{
		for (T item = seed; item != null; item = iterator(item))
		{
			yield return item;
			if (!continues(item))
			{
				break;
			}
		}
	}
}
