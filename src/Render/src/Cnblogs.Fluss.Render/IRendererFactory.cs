using System;

namespace Cnblogs.Fluss.Render
{
    public interface IRendererFactory
    {
        IRenderer CreateRenderer(Guid rendererId);
    }
}