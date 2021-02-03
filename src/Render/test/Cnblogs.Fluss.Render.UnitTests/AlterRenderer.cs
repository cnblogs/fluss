using System.Threading.Tasks;

namespace Cnblogs.Fluss.Render.UnitTests
{
    internal class AlterRenderer : IRenderer
    {
        /// <inheritdoc />
        public async Task<string> RenderAsync(string input, string config)
        {
            return await Task.Run(() => input);
        }
    }
}