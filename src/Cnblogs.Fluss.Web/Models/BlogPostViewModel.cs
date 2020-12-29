using System;

namespace Cnblogs.Fluss.Web.Models
{
    public class BlogPostViewModel
    {
        /// <summary>
        /// 博文 Id。
        /// </summary>
        public long Id { get; set; }

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
    }
}