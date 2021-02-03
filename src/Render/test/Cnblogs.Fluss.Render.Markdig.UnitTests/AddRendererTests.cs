using Cnblogs.Fluss.Render.Extensions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Cnblogs.Fluss.Render.Markdig.UnitTests
{
    public class AddRendererTests
    {
        [Fact]
        public void AddRenderer_UseDefault_AddMarkdigRenderer()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddRenderPipeline(p => p.AddMarkdigRenderer());

            // Assert
            services.BuildServiceProvider().GetRequiredService<IOptions<MarkdigRendererOptions>>().Should().NotBeNull();
            services.Should().ContainSingle(s => s.ServiceType == typeof(MarkdigRenderer));
        }
    }
}