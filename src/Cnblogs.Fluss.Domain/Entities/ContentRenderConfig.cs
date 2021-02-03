using System;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// Render configs for <see cref="ContentBlock"/>.
    /// </summary>
    public class ContentRenderConfig : Entity<long>
    {
        /// <summary>
        /// The id of <see cref="ContentBlock" /> it belongs.
        /// </summary>
        public Guid ContentBlockId { get; set; }

        /// <summary>
        /// The id of renderer it uses.
        /// </summary>
        public Guid RendererId { get; set; }

        /// <summary>
        /// The order of this config in render pipeline.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The config for renderer to use, usually a json string.
        /// </summary>
        public string RendererData { get; set; } = string.Empty;

        /// <summary>
        /// Soft-deletion mark.
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// Creation time.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Last updated time.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}