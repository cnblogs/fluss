using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Cnblogs.Fluss.Render.UnitTests
{
    public class DefaultRendererFactoryTests
    {
        [Fact]
        public void CreateRenderer_RendererExists_ReturnRenderer()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var factory = BuildRendererFactoryWithRenderer(guid, new AlterRenderer());

            // Act
            var actual = factory.CreateRenderer(guid);

            // Assert
            actual.Should().BeOfType<AlterRenderer>();
        }

        [Fact]
        public void CreateRenderer_RendererNotExists_ReturnDefault()
        {
            // Arrange
            var guid = Guid.NewGuid();
            var factory = BuildRendererFactoryWithRenderer(guid, new AlterRenderer());

            // Act
            var actual = factory.CreateRenderer(Guid.NewGuid());

            // Assert
            actual.Should().BeOfType<DefaultRenderer>();
        }

        private static DefaultRendererFactory BuildRendererFactoryWithRenderer<TRenderer>(Guid id, TRenderer renderer)
        {
            var sp = new Mock<IServiceProvider>();
            sp.Setup(s => s.GetService(typeof(TRenderer))).Returns(renderer);
            sp.Setup(s => s.GetService(typeof(DefaultRenderer))).Returns(new DefaultRenderer());

            var option = new OptionsWrapper<RendererRegistry>(
                new RendererRegistry { Registry = new Dictionary<Guid, Type> { { id, typeof(TRenderer) } } });
            return new DefaultRendererFactory(sp.Object, option);
        }
    }
}