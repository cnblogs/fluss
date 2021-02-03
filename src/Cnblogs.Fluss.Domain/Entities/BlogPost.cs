using System;
using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Abstractions;

namespace Cnblogs.Fluss.Domain.Entities
{
    /// <summary>
    /// A single blog post.
    /// </summary>
    public class BlogPost : Entity<long>
    {
        /// <summary>
        /// Id of the blog it belongs.
        /// </summary>
        public long BlogId { get; set; }

        /// <summary>
        /// Post title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// User defined post description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Auto-generated post description based on post content.
        /// </summary>
        public string AutoDesc { get; set; } = string.Empty;

        /// <summary>
        /// Post created time.
        /// </summary>
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Last update time of post.
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.Now;

        /// <summary>
        /// Is post can be visit publicly.
        /// </summary>
        public bool IsPublished { get; set; } = true;

        /// <summary>
        /// Is post exist, soft-deletion mark.
        /// </summary>
        public bool IsExist { get; set; } = true;

        /// <summary>
        /// The blog it belongs.
        /// </summary>
        public BlogSite BlogSite { get; set; } = null!;

        /// <summary>
        /// The contents it contains.
        /// </summary>
        public List<ContentBlock> ContentBlocks { get; set; } = null!;

        /// <summary>
        /// The render configuration for each content block.
        /// </summary>
        public List<ContentRenderConfig> ContentRenderConfigs { get; set; } = null!;
    }
}