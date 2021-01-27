using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnblogs.Fluss.Domain.Abstractions;
using Cnblogs.Fluss.Render;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// A single content block, usually contains a single paragraph.
    /// </summary>
    public class ContentBlock : Entity<Guid>
    {
        /// <summary>
        /// The id of the blogs it belongs.
        /// </summary>
        public long BlogId { get; set; }

        /// <summary>
        /// The id of the post it belongs.
        /// </summary>
        public long PostId { get; set; }

        /// <summary>
        /// Raw text for editing, like markdown source code.
        /// </summary>
        public string Raw { get; set; } = string.Empty;

        /// <summary>
        /// Text for display, usually Html code.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The display order in the post it belongs.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Creation time.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Last updated time.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Soft-deletion mark.
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// The blog it belongs.
        /// </summary>
        public BlogSite BlogSite { get; set; } = null!;

        /// <summary>
        /// The post it belongs.
        /// </summary>
        public BlogPost BlogPost { get; set; } = null!;

        /// <summary>
        /// The Render config it uses.
        /// </summary>
        public List<ContentRenderConfig> RenderConfigs { get; set; } = null!;

        /// <summary>
        /// Render content based on its <see cref="Raw"/> and <see cref="RenderConfigs"/>.
        /// </summary>
        /// <param name="renderFactory">The <see cref="IRendererFactory"/> to produce renderers.</param>
        /// <returns>A <see cref="Task"/> when render completes.</returns>
        public async Task RenderAsync(IRendererFactory renderFactory)
        {
            var renderItem = Raw;
            foreach (var config in RenderConfigs.OrderBy(r => r.Order))
            {
                var renderer = renderFactory.CreateRenderer(config.RendererId);
                renderItem = await renderer.RenderAsync(renderItem, config.RendererData);
            }

            Content = renderItem;
        }
    }
}