using System;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// 内容块。
    /// </summary>
    public class ContentBlock : Entity<Guid>
    {
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
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 上次更新时间。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 软删除标记。
        /// </summary>
        public bool IsExist { get; set; } = true;
    }
}