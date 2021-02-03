using System;
using System.Collections.Generic;
using System.Linq;
using Cnblogs.Fluss.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Cnblogs.Fluss.Infrastructure
{
    /// <summary>
    /// Some methods for seeding database.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Migrate database and seed it.
        /// </summary>
        /// <param name="context">The <see cref="BlogDbContext"/> to use.</param>
        public static void MigrateAndSeed(BlogDbContext context)
        {
            var policy = CreatePolicy();
            policy.Execute(
                () =>
                {
                    context.Database.Migrate();
                    if (context.Set<BlogSite>().Any())
                    {
                        return;
                    }

                    Seed(context);
                });
        }

        /// <summary>
        /// Seed database.
        /// </summary>
        /// <param name="context">The <see cref="BlogDbContext"/> to use.</param>
        public static void Seed(BlogDbContext context)
        {
            var blog = new BlogSite { Title = "Fluss", SubTitle = "Cnblogs" };
            context.Add(blog);
            context.SaveChanges();
            var body = new ContentBlock
            {
                BlogId = blog.Id,
                Raw = "<p>content block</p>",
                Content = "<p>content block</p>",
                RenderConfigs = new List<ContentRenderConfig> { new() { RendererId = Guid.Empty } }
            };
            var post = new BlogPost
            {
                Title = "Fluss is an open-source blog engine",
                Description =
                    "based on .NET，fluss can save and display your work plan or blog post. Content block referring can save your time of maintaining same content between different posts",
                AutoDesc =
                    "based on .NET，fluss can save and display your work plan or blog posts. Content block referring can save your time of maintaining same content between different posts",
                ContentBlocks = new List<ContentBlock> { body }
            };
            blog.BlogPosts = new List<BlogPost> { post };
            context.SaveChanges();
        }

        private static Policy CreatePolicy()
        {
            return Policy.Handle<SqlException>().WaitAndRetry(5, _ => TimeSpan.FromSeconds(5));
        }
    }
}