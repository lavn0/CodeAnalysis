using Microsoft.VisualStudio.CodeAnalysis.Phoenix.Extensibility;
using Phx.IR;
using System.Diagnostics;
using System.IO;
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
			// BOMを読み込むためにStreamReaderで読み込み、ReadObjectメソッド引き数に使えるようにするためにMemoryStreamに転写する
			using (var sr = new StreamReader(settingFileName))
			using (var str = new MemoryStream(Encoding.UTF8.GetBytes(sr.ReadToEnd())))
			{
				var serializer = new DataContractJsonSerializer(typeof(PhoenixSettings));
				this.settings = (PhoenixSettings)serializer.ReadObject(str);
			}

			this.m_statisticsService = statisticsService;
		}

		protected void Violate(WarningEmitter warningEmitter, Instruction instruction)
		{
			var violationMessage = this.ReportLocalizedWarning(instruction);
			var sourceContext = instruction.GetSourceContext();
			Debug.WriteLine(
				"{0}({1}) : {2}",
				sourceContext.FileName,
				sourceContext.LineNumber,
				violationMessage.DescriptionString);
			warningEmitter.Add(violationMessage);
		}
	}
}
