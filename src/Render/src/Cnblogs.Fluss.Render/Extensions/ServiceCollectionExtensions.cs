using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cnblogs.Fluss.Render.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRenderPipeline(
            this IServiceCollection services,
            Action<IRenderPipelineBuilder>? configs = null)
        {
            services.AddOptions();
            services.AddSingleton<IRendererFactory, DefaultRendererFactory>();
            var pipelineBuilder = new RenderPipelineBuilder(services);
            configs?.Invoke(pipelineBuilder);
            pipelineBuilder.AddRenderer<DefaultRenderer>(Guid.Empty);
            pipelineBuilder.BuildPipeline();
            return services;
        }
    }
}