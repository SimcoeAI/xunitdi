using Xunit;
using Xunit.Abstractions;

namespace SimcoeAI.Test
{
	public abstract class TestsWithFixture<TFixture>: BaseTest, IClassFixture<TFixture>
		where TFixture : class
	{
		protected readonly TFixture _fixture;

		protected TestsWithFixture(ITestOutputHelper testOutputHelper)
			: base(testOutputHelper)
		{
		}

		protected TestsWithFixture(ITestOutputHelper testOutputHelper, TFixture fixture)
			: this(testOutputHelper)
			=> _fixture = fixture;
	}
}
