using System;
using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Abstractions;

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
        /// 引用的内容块 Id。
        /// </summary>
        public Guid? Refer { get; set; }

        /// <summary>
        /// 内容。
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 被引用的内容块。
        /// </summary>
        public ContentBlock? ReferringBlock { get; set; } = null!;

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// 上次更新时间。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; }

        /// <summary>
        /// 软删除标记。
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// 所属的博客。
        /// </summary>
        public BlogSite BlogSite { get; set; } = null!;

        /// <summary>
        /// 使用该内容块的博文。
        /// </summary>
        public List<BlogPost> BlogPosts { get; set; } = null!;
    }
}