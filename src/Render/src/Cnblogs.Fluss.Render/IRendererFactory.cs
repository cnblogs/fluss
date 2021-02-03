using System;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// Factory for <see cref="IRenderer"/>.
    /// </summary>
    public interface IRendererFactory
    {
        /// <summary>
        /// Get renderer with specific id from DI, if that kind of renderer does not exist, <see cref="DefaultRenderer"/> is returned.
        /// </summary>
        /// <param name="rendererId">The id of renderer.</param>
        /// <returns>The renderer with id of <paramref name="rendererId"/>.</returns>
        /// <exception cref="InvalidOperationException">The renderer type registered with <paramref name="rendererId"/> could not be created with <see cref="IServiceProvider"/>.</exception>
        IRenderer CreateRenderer(Guid rendererId);
    }
}