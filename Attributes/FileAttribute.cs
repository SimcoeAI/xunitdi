using System.IO;
using Xunit.Sdk;

namespace SimcoeAI.Test.Attributes
{
	public abstract class FileAttribute : DataAttribute
	{
		protected readonly string _fileName = string.Empty;

		protected FileAttribute(string filename)
			=> _fileName = filename;

		protected string ReadFile()
		{
			if (!File.Exists(_fileName))
			{
				throw new FileNotFoundException($"File not found: {_fileName}");
			}

			return File.ReadAllText(_fileName);
		}
	}
}
