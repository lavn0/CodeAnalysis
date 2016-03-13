using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FxCopCustomUnitTest
{
	public abstract class BaseFxCopUnitTest
	{
		private const string exePath = @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Team Tools\Static Analysis Tools\FxCop\FxCopCmd.exe";
		private const string outXmlPath = "fxcoplog.xml";

		protected readonly XDocument FxCopResult;

		public BaseFxCopUnitTest()
		{
			this.FxCopResult = this.GetFxCopResult();
		}

		private XDocument GetFxCopResult()
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

				return XDocument.Load(outXmlPath);
			}
		}

		private ProcessStartInfo GetProcessInfo()
		{
			return new ProcessStartInfo(exePath)
			{
				Arguments = string.Format(
					@"/file:""{0}"" /rule:""{1}"" /out:""{2}"" /console",
					new FileInfo("FxCopCustomTestRunLibrary.dll").FullName,
					new FileInfo("FxCopCustom.dll").FullName,
					outXmlPath),
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardInput = false,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
			};
		}

		protected List<XElement> GetMethodErrors(string ruleName)
		{
			string xpath = string.Format("//Member[@Kind='Method']//Message[@TypeName='{0}']", ruleName);
			return this.FxCopResult.XPathSelectElements(xpath).ToList();
		}
	}
}
