using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace PhoenixCustomUnitTest
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.GetCustomAttributes<TestClassAttribute>().Any())
				{
					object instance = null;
					foreach (var method in type.GetMethods())
					{
						if (method.GetCustomAttributes<TestMethodAttribute>().Any())
						{
							instance = instance ?? type.GetConstructor(System.Type.EmptyTypes).Invoke(new object[0]);
							method.Invoke(instance, new object[0]);
						}
					}
				}
			}
		}
	}
}
