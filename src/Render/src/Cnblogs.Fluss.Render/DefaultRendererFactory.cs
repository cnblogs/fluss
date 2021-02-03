using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// render factory, can be singleton.
    /// </summary>
    public class DefaultRendererFactory : IRendererFactory
    {
        private readonly IServiceProvider _sp;
        private readonly RendererRegistry _cache;

        public DefaultRendererFactory(IServiceProvider sp, IOptions<RendererRegistry> cache)
        {
            _sp = sp;
            _cache = cache.Value;
        }

        /// <inheritdoc />
        public IRenderer CreateRenderer(Guid rendererId)
        {
            var type = _cache.Get(rendererId) ?? typeof(DefaultRenderer);
            return _sp.GetRequiredService(type) as IRenderer ?? new DefaultRenderer();
        }
    }
}