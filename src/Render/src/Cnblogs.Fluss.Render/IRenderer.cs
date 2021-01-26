using System.Threading.Tasks;

namespace Cnblogs.Fluss.Render
{
    public interface IRenderer
    {
        Task<string> RenderAsync(string input, string config);
    }
}