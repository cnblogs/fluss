using System;
using Cnblogs.Fluss.Render.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cnblogs.Fluss.Render.Markdig
{
    /// <summary>
    /// Extension method that adds <see cref="MarkdigRenderer"/> to the render pipeline.
    /// </summary>
    public static class RenderPipelineExtensions
    {
        /// <summary>
        /// Adds Markdig renderer to the <see cref="IRenderPipelineBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IRenderPipelineBuilder"/>.</param>
        /// <param name="configure">optional configuration to the <see cref="MarkdigRendererOptions"/>.</param>
        /// <returns>The <see cref="IRenderPipelineBuilder"/>.</returns>
        public static IRenderPipelineBuilder AddMarkdigRenderer(
            this IRenderPipelineBuilder builder,
            Action<MarkdigRendererOptions>? configure = null)
        {
            configure ??= _ => { };
            builder.Services.Configure(configure);
            return builder.AddRenderer<MarkdigRenderer>();
        }
    }
}