using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Cnblogs.Fluss.Render.Extensions
{
    internal class RenderPipelineBuilder : IRenderPipelineBuilder
    {
        private readonly IServiceCollection _services;
        private readonly List<(Guid, Type)> _registry = new();

        public RenderPipelineBuilder(IServiceCollection services)
        {
            _services = services;
        }

        /// <inheritdoc />
        public IRenderPipelineBuilder AddRenderer<TRenderer>(Guid id)
            where TRenderer : class, IRenderer
        {
            _services.AddTransient<TRenderer>();
            _registry.Add((id, typeof(TRenderer)));
            return this;
        }

        public void BuildPipeline()
        {
            _services.Configure<RendererRegistry>(r => _registry.ForEach(i => r.TryAdd(i.Item1, i.Item2)));
        }
    }
}