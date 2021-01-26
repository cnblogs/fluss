using System;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// 内容块渲染配置。
    /// </summary>
    public class ContentRenderConfig : Entity<long>
    {
        /// <summary>
        /// 内容块 Id。
        /// </summary>
        public Guid ContentBlockId { get; set; }

        /// <summary>
        /// 渲染器 Id。
        /// </summary>
        public Guid RendererId { get; set; }

        /// <summary>
        /// 渲染器顺序。
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 渲染器配置。
        /// </summary>
        public string RendererData { get; set; } = string.Empty;

        /// <summary>
        /// 软删除标记。
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// 添加时间。
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 上次修改时间。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;
    }
}