using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Phx.IR;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PhoenixCustom
{
	internal abstract class BasePhoenixCustomRule : PhoenixRule
	{
		private const string settingFileName = "phoenixSettings.json";

		protected readonly PhoenixSettings settings;
		protected readonly StatisticsService m_statisticsService;

		public BasePhoenixCustomRule(StatisticsService statisticsService)
		{
			var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var fileName = Path.Combine(directory, settingFileName);

			// BOMを読み込むためにStreamReaderで読み込み、ReadObjectメソッド引き数に使えるようにするためにMemoryStreamに転写する
			using (var sr = new StreamReader(fileName))
			using (var str = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
			{
				var serializer = new DataContractJsonSerializer(typeof(PhoenixSettings));
				this.settings = (PhoenixSettings)serializer.ReadObject(str);
			}

			this.m_statisticsService = statisticsService;
		}

		protected void Violate(WarningEmitter warningEmitter, Instruction instruction, params object[] args)
		{
			var violationMessage = this.ReportLocalizedWarning(instruction, args);
			Debug.WriteLine(violationMessage.ToString(), args);
			warningEmitter.Add(violationMessage);
		}
	}
}
