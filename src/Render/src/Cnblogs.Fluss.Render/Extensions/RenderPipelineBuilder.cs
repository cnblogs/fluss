using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cnblogs.Fluss.Render.Extensions
{
    internal class RenderPipelineBuilder : IRenderPipelineBuilder
    {
        private readonly Dictionary<Guid, Type> _registry = new();

        public RenderPipelineBuilder(IServiceCollection services)
        {
            Services = services;
        }

        /// <inheritdoc />
        public IServiceCollection Services { get; }

        /// <inheritdoc />
        public IRenderPipelineBuilder AddRenderer<TRenderer>()
            where TRenderer : class, IRenderer
        {
            var id = typeof(TRenderer).GetCustomAttribute<RendererIdAttribute>()?.RendererId
                     ?? ThrowNoRendererId<TRenderer>();
            return AddRenderer<TRenderer>(id);
        }

        /// <inheritdoc />
        public IRenderPipelineBuilder AddRenderer<TRenderer>(Guid id)
            where TRenderer : class, IRenderer
        {
            if (_registry.ContainsKey(id) && _registry[id] != typeof(TRenderer))
            {
                return ThrowIdAlreadyBeenRegistered(id, _registry[id].Name);
            }

            Services.TryAddTransient<TRenderer>();
            _registry.TryAdd(id, typeof(TRenderer));
            return this;
        }

        /// <summary>
        /// Add the registry to <see cref="RendererRegistry"/>.
        /// </summary>
        internal void BuildPipeline()
        {
            Services.Configure<RendererRegistry>(r => r.Registry = _registry);
        }

        [DoesNotReturn]
        private static Guid ThrowNoRendererId<TRenderer>()
        {
            throw new InvalidOperationException(
                $"The Renderer {typeof(TRenderer).Name} does not contains {nameof(RendererIdAttribute)}");
        }

        [DoesNotReturn]
        private static IRenderPipelineBuilder ThrowIdAlreadyBeenRegistered(Guid id, string rendererName)
        {
            throw new InvalidOperationException($"{id} is already registered to {rendererName}");
        }
    }
}