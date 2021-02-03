using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cnblogs.Fluss.Render.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add <see cref="IRendererFactory"/> and default renderers to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="renderConfiguration">An optional config to the render pipeline, e.x. inject custom renderers.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddRenderPipeline(
            this IServiceCollection services,
            Action<IRenderPipelineBuilder>? renderConfiguration = null)
        {
            services.AddSingleton<IRendererFactory, DefaultRendererFactory>();
            var pipelineBuilder = new RenderPipelineBuilder(services);
            renderConfiguration?.Invoke(pipelineBuilder);
            pipelineBuilder.AddRenderer<DefaultRenderer>(Guid.Empty);
            pipelineBuilder.BuildPipeline();
            return services;
        }
    }
}