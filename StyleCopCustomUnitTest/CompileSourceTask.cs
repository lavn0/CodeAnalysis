using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TestUtility
{
	public class CompileSourceTask : Task
	{
		[Required]
		public string OutputPath { get; set; }

		[Required]
		public ITaskItem[] InputTestSources { get; set; }

		public override bool Execute()
		{
			foreach (var item in InputTestSources)
			{
				this.Log.LogMessage("ItemSpec = " + item.ItemSpec);
				var sourceText = File.ReadAllText(item.ItemSpec);
				var outputText = Regex.Replace(sourceText, @"^[\t ]*//\s*ERROR\((\s*(?<start>\d+)\s*(,\s*(?<end>\d+)\s*)?)?\).*?\n", string.Empty, RegexOptions.Multiline);
				var outputPath = Path.Combine(OutputPath, item.ItemSpec);
				Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
				File.WriteAllText(outputPath, outputText);
			}

			this.Log.LogCommandLine("CustomTask parsed " + InputTestSources.Length + " files.");
			return true;
		}
	}
}
