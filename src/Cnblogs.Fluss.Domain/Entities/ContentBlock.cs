using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cnblogs.Fluss.Domain.Abstractions;
using Cnblogs.Fluss.Render;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// 内容块。
    /// </summary>
    public class ContentBlock : Entity<Guid>
    {
        /// <summary>
        /// 所属的博客 Id。
        /// </summary>
        public long BlogId { get; set; }

        /// <summary>
        /// 所属的博文 Id。
        /// </summary>
        public long PostId { get; set; }

        /// <summary>
        /// 可编辑的文本。
        /// </summary>
        public string Raw { get; set; } = string.Empty;

        /// <summary>
        /// 可显示的内容。
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 出现顺序。
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 上次更新时间。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 软删除标记。
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// 所属的博客。
        /// </summary>
        public BlogSite BlogSite { get; set; } = null!;

        /// <summary>
        /// 所属的博文。
        /// </summary>
        public BlogPost BlogPost { get; set; } = null!;

        /// <summary>
        /// 使用该内容块的博文记录。
        /// </summary>
        public List<ContentRenderConfig> RenderConfigs { get; set; } = null!;

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