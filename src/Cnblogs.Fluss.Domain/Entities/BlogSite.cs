using System;
using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// A single blog and its configs.
    /// </summary>
    public class BlogSite : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// Blog title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Blog subtitle.
        /// </summary>
        public string SubTitle { get; set; } = string.Empty;

        /// <summary>
        /// The page size for blog home page.
        /// </summary>
        public int HomePageSize { get; set; } = 15;

        /// <summary>
        /// Soft-deletion mark.
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// Creation time for the blog.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Last update time for the blog.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// The posts it contains.
        /// </summary>
        public List<BlogPost> BlogPosts { get; set; } = null!;

        /// <summary>
        /// The content is contains.
        /// </summary>
        public List<ContentBlock> ContentBlocks { get; set; } = null!;
    }
}