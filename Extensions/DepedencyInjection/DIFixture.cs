using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimcoeAI.Test.Logging;
using System;
using System.IO;
using Xunit.Abstractions;

namespace SimcoeAI.Test.Extensions.DepedencyInjection
{
	public abstract class DIFixture
	{	
		private readonly IServiceCollection _services;
		private IServiceProvider _serviceProvider;

		protected DIFixture()
		{
			Configuration = GetConfigurationRoot() as IConfiguration;
			_services = new ServiceCollection();
			AddServices(_services);
		}

		public IConfiguration Configuration { get; }

		public IServiceProvider GetServiceProvider(ITestOutputHelper testOutputHelper)
		{
			if(_serviceProvider != default)
			{
				return _serviceProvider;
			}

			_services.AddLogging(loggingBuilder => loggingBuilder.AddProvider(new OutputLoggerProvider(testOutputHelper)));
			return _serviceProvider = _services.BuildServiceProvider();
		}

		public void AddOutputHelperToLoggerProvider(ITestOutputHelper testOutputHelper)
			=> _services.AddScoped<ILoggerProvider>(_ => new OutputLoggerProvider(testOutputHelper));

		protected abstract string GetConfigurationFile();
		protected abstract void AddServices(IServiceCollection services);

		private IConfigurationRoot GetConfigurationRoot(string configurationFile) =>
			new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile(configurationFile)
			.Build();

		private IConfigurationRoot GetConfigurationRoot()
		{
			var configurationFile = GetConfigurationFile();

			return
				!string.IsNullOrEmpty(configurationFile)
				? GetConfigurationRoot(configurationFile)
				: default;
		}
	}
}
