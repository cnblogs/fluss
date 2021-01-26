using System;
using System.Collections.Generic;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// 渲染器缓存，需要被注入为 Singleton
    /// </summary>
    public class RendererRegistry
    {
        private readonly Dictionary<Guid, Type> _registry = new();

        public bool TryAdd(Guid id, Type renderer)
        {
            return _registry.TryAdd(id, renderer);
        }

        public Type? Get(Guid id)
        {
            return _registry.ContainsKey(id) ? _registry[id] : null;
        }
    }
}