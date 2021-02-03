using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Cnblogs.Fluss.Render.UnitTests
{
    public class DefaultRendererTests
    {
        [Fact]
        public async Task RenderAsync_RenderAsIs()
        {
            // Arrange
            const string input = "input";
            var config = string.Empty;

            // Act
            var rendered = await new DefaultRenderer().RenderAsync(input, config);

            // Assert
            rendered.Should().BeEquivalentTo(input);
        }
    }
}