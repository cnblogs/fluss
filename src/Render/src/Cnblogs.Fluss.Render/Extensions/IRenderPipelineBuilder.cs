using System;

namespace Cnblogs.Fluss.Render.Extensions
{
    public interface IRenderPipelineBuilder
    {
        IRenderPipelineBuilder AddRenderer<TRenderer>(Guid id)
            where TRenderer : class, IRenderer;
    }
}