using System;
using System.Collections.Generic;

namespace Cnblogs.Fluss.Render
{
    /// <summary>
    /// Renderer registry, needs to be injected with singleton lifetime
    /// </summary>
    public class RendererRegistry
    {
        /// <summary>
        /// The registry contains id and type.
        /// </summary>
        public Dictionary<Guid, Type> Registry { get; set; } = new();

        /// <summary>
        /// Get renderer type based on renderer id, if renderer is not exists, <see langword="null"/> is returned
        /// </summary>
        /// <param name="id">renderer id.</param>
        /// <returns>The renderer type associates with <paramref name="id"/>, if no renderer type is found then <see langword="null"/> is returned.</returns>
        public Type? Get(Guid id)
        {
            return Registry.ContainsKey(id) ? Registry[id] : null;
        }
    }
}