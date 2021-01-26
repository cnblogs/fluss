using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// 渲染器工厂
    /// </summary>
    public class DefaultRendererFactory : IRendererFactory
    {
        private readonly IServiceProvider _sp;
        private readonly IOptions<RendererRegistry> _cache;

        public DefaultRendererFactory(IServiceProvider sp, IOptions<RendererRegistry> cache)
        {
            _sp = sp;
            _cache = cache;
        }

        /// <inheritdoc />
        public IRenderer CreateRenderer(Guid rendererId)
        {
            var type = _cache.Value.Get(rendererId) ?? typeof(DefaultRenderer);
            return _sp.GetRequiredService(type) as IRenderer ?? new DefaultRenderer();
        }
    }
}