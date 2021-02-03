using System;

namespace Cnblogs.Fluss.Render.Extensions
{
    /// <summary>
    /// Render pipeline configuration builder.
    /// </summary>
    public interface IRenderPipelineBuilder
    {
        /// <summary>
        /// Add renderer, with id from the <see cref="RendererIdAttribute"/> that <typeparamref name="TRenderer"/> contains.
        /// </summary>
        /// <typeparam name="TRenderer">The renderer that needs to add.</typeparam>
        /// <returns>The <see cref="IRenderPipelineBuilder"/>.</returns>
        /// <exception cref="InvalidOperationException"><typeparamref name="TRenderer"/> does not contain <see cref="RendererIdAttribute"/>.</exception>
        IRenderPipelineBuilder AddRenderer<TRenderer>()
            where TRenderer : class, IRenderer;

        /// <summary>
        /// Add Renderer with specific id, the id in <see cref="RendererIdAttribute"/> would be ignored.
        /// </summary>
        /// <param name="id">The id that renderer register with.</param>
        /// <typeparam name="TRenderer">The <see cref="IRenderPipelineBuilder"/>.</typeparam>
        /// <returns>The <see cref="IRenderPipelineBuilder"/>.</returns>
        /// <exception cref="InvalidOperationException">The <paramref name="id"/> has already registered with another renderer type.</exception>
        IRenderPipelineBuilder AddRenderer<TRenderer>(Guid id)
            where TRenderer : class, IRenderer;
    }
}