using System;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// Specify id for renderer in registry.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RendererIdAttribute : Attribute
    {
        /// <summary>
        /// Create a <see cref="RendererIdAttribute"/>.
        /// </summary>
        /// <param name="rendererId">The guid of the renderer.</param>
        public RendererIdAttribute(string rendererId)
        {
            RendererId = Guid.Parse(rendererId);
        }

        /// <summary>
        /// The id for renderer.
        /// </summary>
        public Guid RendererId { get; }
    }
}