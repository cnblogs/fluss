using System;
using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// 博客设置。
    /// </summary>
    public class BlogSite : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 博客标题。
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 博客副标题。
        /// </summary>
        public string SubTitle { get; set; } = string.Empty;

        /// <summary>
        /// 博客首页分页列表数。
        /// </summary>
        public int HomePageSize { get; set; } = 15;

        /// <summary>
        /// 博客创建时间。
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 博客上次更新时间。
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// 博文列表。
        /// </summary>
        public List<BlogPost> BlogPosts { get; set; } = null!;
    }
}