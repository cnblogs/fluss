using System.Threading.Tasks;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// Renderer.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Render the input with specific config.
        /// </summary>
        /// <param name="input">The string input for render.</param>
        /// <param name="config">The string config used for render, usually a json string.</param>
        /// <returns>A <see cref="Task"/> that completes with rendered string.</returns>
        Task<string> RenderAsync(string input, string config);
    }
}