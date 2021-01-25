using System;
using System.Collections.Generic;
using System.Linq;
using Cnblogs.Fluss.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Cnblogs.Fluss.Infrastructure
{
    public static class SeedData
    {
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

        public static void Seed(BlogDbContext context)
        {
            var blog = new BlogSite { Title = "Fluss", SubTitle = "Cnblogs" };
            context.Add(blog);
            context.SaveChanges();
            var body = new ContentBlock { BlogId = blog.Id, Content = "<p>content block can be referred</p>" };
            var post = new BlogPost
            {
                Title = "Fluss is an open-source blog engine",
                Description =
                    "based on .NET，fluss can save and display your work plan or blog post. Content block referring can save your time of maintaining same content between different posts",
                AutoDesc =
                    "based on .NET，fluss can save and display your work plan or blog posts. Content block referring can save your time of maintaining same content between different posts",
                ContentRecords = new List<PostContentRecord>()
            };
            post.ContentRecords.Add(new PostContentRecord { BlogPost = post, ContentBlock = body, Order = 2 });
            blog.BlogPosts = new List<BlogPost> { post };
            context.SaveChanges();
            var referBlock = new ContentBlock { BlogId = blog.Id, Refer = body.Id };
            post.ContentRecords.Add(new PostContentRecord { BlogPost = post, ContentBlock = referBlock, Order = 1 });
            context.SaveChanges();
        }

        private static Policy CreatePolicy()
        {
            return Policy.Handle<SqlException>().WaitAndRetry(5, _ => TimeSpan.FromSeconds(5));
        }
    }
}