using System;
using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// 博文。
    /// </summary>
    public class BlogPost : Entity<long>
    {
        /// <summary>
        /// 博客 Id。
        /// </summary>
        public long BlogId { get; set; }

        /// <summary>
        /// 博文标题。
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 博文描述。
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 博文自动生成的描述。
        /// </summary>
        public string AutoDesc { get; set; } = string.Empty;

        /// <summary>
        /// 博文创建时间。
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 博文上次更新时间。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 是否发布。
        /// </summary>
        public bool IsPublished { get; set; } = true;

        /// <summary>
        /// 软删除标记。
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// 所属博客。
        /// </summary>
        public BlogSite BlogSite { get; set; } = null!;

        /// <summary>
        /// 博文内容块记录。
        /// </summary>
        public List<ContentBlock> ContentBlocks { get; set; } = null!;

        /// <summary>
        /// 博文内容渲染记录。
        /// </summary>
        public List<ContentRenderConfig> ContentRenderConfigs { get; set; } = null!;
    }
}