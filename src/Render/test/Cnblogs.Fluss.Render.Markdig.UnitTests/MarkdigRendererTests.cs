using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Xunit;

namespace Cnblogs.Fluss.Render.Markdig.UnitTests
{
    public class MarkdigRendererTests
    {
        [Fact]
        public async Task RenderAsync_RenderMarkdown()
        {
            // Arrange
            const string input = "`code`";
            const string expected = "<p><code>code</code></p>";
            var option = new OptionsWrapper<MarkdigRendererOptions>(new MarkdigRendererOptions());
            var renderer = new MarkdigRenderer(option);

            // Act
            var actual = await renderer.RenderAsync(input, string.Empty);

            // Assert
            actual.Trim().Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task RenderAsync_OverrideByBlockConfig()
        {
            // Arrange
            const string input = "$math$";
            const string expected = "<p>$math$</p>";
            var option = new OptionsWrapper<MarkdigRendererOptions>(new MarkdigRendererOptions());
            var renderer = new MarkdigRenderer(option);

            // Act
            var actual = await renderer.RenderAsync(input, "common");

            // Assert
            actual.Trim().Should().BeEquivalentTo(expected);
        }
    }
}