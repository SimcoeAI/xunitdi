using Microsoft.Extensions.DependencyInjection;
using SimcoeAI.Test.Extensions.DepedencyInjection;
using Xunit.Abstractions;

namespace SimcoeAI.Test.Extensions
{
    public static class FixtureExtensions
    {
		public static T GetService<T>(this DIFixture fixture, ITestOutputHelper testOutputHelper)
			=> fixture.GetServiceProvider(testOutputHelper).GetService<T>();

		public static T GetScopedService<T>(this DIFixture fixture, ITestOutputHelper testOutputHelper)
		{
			using var scope = fixture.GetServiceProvider(testOutputHelper).CreateScope();
			return scope.ServiceProvider.GetService<T>();
		}
	}
}
