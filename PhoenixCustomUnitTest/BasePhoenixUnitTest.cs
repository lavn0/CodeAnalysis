﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PhoenixCustomUnitTest
{
	public abstract class BasePhoenixUnitTest
	{
		private const string outXmlPath = "fxcoplog.xml";
		private static readonly string exePath;

		protected static readonly XDocument FxCopResult;

		static BasePhoenixUnitTest()
		{
			var majorVersion = Assembly.LoadFile(new FileInfo("PhoenixCustom.dll").FullName)
				.GetReferencedAssemblies()
				.First(a => a.Name == "phx")
				.Version.Major;
			exePath =
				majorVersion == 16 ? @"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Team Tools\Static Analysis Tools\FxCop\FxCopCmd.exe" :
				majorVersion == 15 ? @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Team Tools\Static Analysis Tools\FxCop\FxCopCmd.exe" :
				majorVersion == 14 ? @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Team Tools\Static Analysis Tools\FxCop\FxCopCmd.exe" :
				majorVersion == 12 ? @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Team Tools\Static Analysis Tools\FxCop\FxCopCmd.exe" :
				majorVersion == 11 ? @"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Team Tools\Static Analysis Tools\FxCop\FxCopCmd.exe" : null;

			if (!File.Exists(exePath))
			{
				Debugger.Break();
				throw new FileNotFoundException(exePath);
			}

			FxCopResult = GetFxCopResult();
		}

		private static XDocument GetFxCopResult()
		{
			using (var process = new Process() { StartInfo = GetProcessInfo() })
			{
				if (!process.Start())
				{
					throw new InvalidOperationException("Could not successfully start FxCop process.");
				}

				process.WaitForExit(10000);

				if (process.ExitCode != 0)
				{
					throw new InvalidOperationException(string.Format("FxCop returned exit code of {0}.", process.ExitCode));
				}

				return File.Exists(outXmlPath) ? XDocument.Load(outXmlPath) : null; // エラーがない場合はログファイルが出力されない
			}
		}

		private static ProcessStartInfo GetProcessInfo()
		{
			return new ProcessStartInfo(exePath)
			{
				Arguments = string.Format(
					@"/file:""{0}"" /rule:""{1}"" /out:""{2}"" /console",
					new FileInfo("PhoenixCustomUnitTest.dll").FullName,
					new FileInfo("PhoenixCustom.dll").FullName,
					outXmlPath),
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden,
			};
		}

		protected List<XElement> GetErrors(string ruleName)
		{
			string xpath = string.Format("//Message[@TypeName='{0}']//Issue", ruleName);
			return FxCopResult.XPathSelectElements(xpath).ToList();
		}

		protected List<XElement> GetErrors(string ruleName, string targetTypeName)
		{
			string xpath = string.Format("//Type[@Kind='Class'][@Name='{1}']//Message[@TypeName='{0}']//Issue", ruleName, targetTypeName);
			return FxCopResult.XPathSelectElements(xpath).ToList();
		}

		protected List<XElement> GetErrors(string ruleName, string targetTypeName, string methodName)
		{
			string xpath = string.Format("//Type[@Kind='Class'][@Name='{1}']//Member[@Kind='Method'][@Name='#{2}']//Message[@TypeName='{0}']//Issue", ruleName, targetTypeName, methodName);
			return FxCopResult.XPathSelectElements(xpath).ToList();
		}

		protected XElement GetError(string ruleName, string targetTypeName, string methodName)
		{
			string xpath = string.Format("//Type[@Kind='Class'][@Name='{1}']//Member[@Kind='Method'][@Name='#{2}']//Message[@TypeName='{0}']//Issue", ruleName, targetTypeName, methodName);
			return FxCopResult.XPathSelectElement(xpath);
		}
	}
}
