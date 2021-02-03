using System.Threading.Tasks;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// Default renderer, render input as is.
    /// </summary>
    [RendererId("00000000-0000-0000-0000-000000000000")]
    public class DefaultRenderer : IRenderer
    {
        /// <inheritdoc />
        public async Task<string> RenderAsync(string input, string config)
        {
            return await Task.Run(() => input);
        }
    }
}