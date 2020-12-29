using System;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// 博文-内容块关联类。
    /// </summary>
    public class PostContent
    {
        /// <summary>
        /// 博文 Id。
        /// </summary>
        public long PostId { get; set; }

        /// <summary>
        /// 内容块 Id。
        /// </summary>
        public Guid ContentBlockId { get; set; }

        /// <summary>
        /// 出现次序。
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 软删除标记。
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// 添加日期。
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 更新日期。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 博文。
        /// </summary>
        public BlogPost BlogPost { get; set; } = null!;

        /// <summary>
        /// 内容块。
        /// </summary>
        public ContentBlock ContentBlock { get; set; } = null!;
    }
}