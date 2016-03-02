using StyleCop;
using System;
using System.Collections.Generic;
using System.IO;

namespace StyleCopContrib.Runner
{
	public static class ProjectUtility
	{
		public static CodeProject CreateCodeProject(string codeFile, string settingsLocation, StyleCopEnvironment environment)
		{
			return ProjectUtility.CreateCodeProject(new List<string> { codeFile }, settingsLocation, environment);
		}

		public static CodeProject CreateCodeProject(IEnumerable<string> codeFiles, string location, StyleCopEnvironment environment)
		{
			var codeProject = new CodeProject(Guid.NewGuid().GetHashCode(), location, new Configuration(new string[0]));

			foreach (string codeFile in codeFiles)
			{
				if (!File.Exists(codeFile))
				{
					throw new FileNotFoundException("File " + codeFile + " not found.", codeFile);
				}

				environment.AddSourceCode(codeProject, Path.GetFullPath(codeFile), null);
			}

			return codeProject;
		}
	}
}
