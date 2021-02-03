using System;
using System.Reflection;
using Cnblogs.Fluss.Render.Extensions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace Cnblogs.Fluss.Render.UnitTests
{
    public class AddRenderPipelineTests
    {
        private readonly Guid _defaultRendererId =
            typeof(DefaultRenderer).GetCustomAttribute<RendererIdAttribute>()?.RendererId
            ?? throw new InvalidOperationException();

        [Fact]
        public void AddRenderer_AddSameRendererMultipleTimes_OnlyAddOnce()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddRenderPipeline(
                o =>
                {
                    o.AddRenderer<DefaultRenderer>();
                    o.AddRenderer<DefaultRenderer>();
                });
            var registry = services.BuildServiceProvider().GetRequiredService<IOptions<RendererRegistry>>().Value;

            // Assert
            services.Should().ContainSingle(s => s.ServiceType == typeof(DefaultRenderer));
            registry.Get(_defaultRendererId).Should().Be(typeof(DefaultRenderer));
        }

        [Fact]
        public void AddRenderer_NoExtraConfig_OnlyAddDefaultRenderer()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddRenderPipeline();
            var registry = services.BuildServiceProvider().GetRequiredService<IOptions<RendererRegistry>>().Value;

            // Assert
            services.Should().ContainSingle(s => s.ServiceType == typeof(DefaultRenderer));
            registry.Get(_defaultRendererId).Should().Be<DefaultRenderer>();
        }

        [Fact]
        public void AddRenderer_AddSameRendererWithDifferentId_MultipleIdToSameRenderer()
        {
            // Arrange
            var services = new ServiceCollection();
            var alterRendererId = Guid.NewGuid();

            // Act
            services.AddRenderPipeline(
                o =>
                {
                    o.AddRenderer<DefaultRenderer>(alterRendererId);
                });
            var registry = services.BuildServiceProvider().GetRequiredService<IOptions<RendererRegistry>>().Value;

            // Assert
            services.Should().ContainSingle(s => s.ServiceType == typeof(DefaultRenderer));
            registry.Get(_defaultRendererId).Should().Be<DefaultRenderer>();
            registry.Get(alterRendererId).Should().Be<DefaultRenderer>();
        }

        [Fact]
        public void AddRenderer_AddDifferentRendererWithSameId_ThrowsException()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            Action act = () => services.AddRenderPipeline(
                o =>
                {
                    o.AddRenderer<DefaultRenderer>(_defaultRendererId);
                    o.AddRenderer<AlterRenderer>(_defaultRendererId);
                });

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AddRenderer_AddRendererWithoutAttributeOrExplicitId_ThrowsException()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            Action act = () => services.AddRenderPipeline(
                o =>
                {
                    o.AddRenderer<AlterRenderer>();
                });

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}