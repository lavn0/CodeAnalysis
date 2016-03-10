using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StyleCopContrib.Runner
{
	public static class StyleCopUtil
	{
		public static AnalysisResults RunStyleCop(string settingPath, string codeFile)
		{
			return RunStyleCop(settingPath, new List<string>() { codeFile });
		}

		public static AnalysisResults RunStyleCop(string settingPath, List<string> codeFiles)
		{
			var fileDirectory = Path.GetDirectoryName(codeFiles.First());
			var runner = new ConsoleRunner(settingPath, null);
			var project = ProjectUtility.CreateCodeProject(codeFiles, settingPath, runner.Environment);
			return runner.Analyze(project);
		}
	}
}
