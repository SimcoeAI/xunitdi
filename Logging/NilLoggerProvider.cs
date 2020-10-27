using Microsoft.Extensions.Logging;

namespace SimcoeAI.Test.Logging
{
	public sealed class NilLoggerProvider : ILoggerProvider
	{
		public ILogger CreateLogger(string categoryName)
			=> null;

		public void Dispose()
		{
		}
	}
}
