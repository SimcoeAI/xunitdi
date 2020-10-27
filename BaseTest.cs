using System;
using Xunit.Abstractions;


namespace SimcoeAI.Test
{
	public abstract class BaseTest : IDisposable
	{
		private bool disposedValue = false;
		protected readonly ITestOutputHelper _testOutputHelper;

		protected BaseTest(ITestOutputHelper testOutputHelper)
			=> _testOutputHelper = testOutputHelper;

		protected virtual void Cleanup() { }

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					Cleanup();
				}
				disposedValue = true;
			}
		}

		public void Dispose() => Dispose(true);
	}
}
