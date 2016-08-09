using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace StyleCopCustomUnitTest
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.GetCustomAttributes<TestClassAttribute>().Any())
				{
					var ls = new List<Exception>();
					object instance = null;
					foreach (var method in type.GetMethods())
					{
						if (method.GetCustomAttributes<TestMethodAttribute>().Any())
						{
							instance = instance ?? type.GetConstructor(System.Type.EmptyTypes).Invoke(new object[0]);
							try
							{
								method.Invoke(instance, new object[0]);
							}
							catch (Exception ex)
							{
								ls.Add(ex);
							}
						}
					}

					if (ls.Any())
					{
						var message = string.Join(Environment.NewLine, ls.Select(ex => ex.InnerException.Message));
						Debug.WriteLine("Error: " + message);
						Console.WriteLine("Error: " + message);
					}
				}
			}
		}
	}
}
