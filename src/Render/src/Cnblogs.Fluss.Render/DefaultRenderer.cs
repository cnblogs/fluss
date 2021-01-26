using System.Threading.Tasks;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// 默认渲染器，直接返回输入值。
    /// </summary>
    public class DefaultRenderer : IRenderer
    {
        /// <inheritdoc />
        public async Task<string> RenderAsync(string input, string config)
        {
            return await Task.Run(() => input);
        }
    }
}