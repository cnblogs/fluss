using System.Collections.Generic;
using Cnblogs.Fluss.Domain.Entities;

namespace Cnblogs.Fluss.Infrastructure
{
    public static class SeedData
    {
        public static void Seed(BlogDbContext context)
        {
            context.Database.EnsureCreated();
            var blog = new BlogSite { Title = "Fluss", SubTitle = "博客园团队" };
            context.Add(blog);
            context.SaveChanges();
            var body = new ContentBlock() { BlogId = blog.Id, Content = "博文内容块之间可以相互引用" };
            var post = new BlogPost
            {
                Title = "Fluss 是一个开源的博客引擎",
                ContentBlocks = new List<ContentBlock> { body }
            };
            blog.BlogPosts = new List<BlogPost> { post };
            context.SaveChanges();
            var referBlock = new ContentBlock() { BlogId = blog.Id, Refer = body.Id };
            post.ContentBlocks.Add(referBlock);
            context.SaveChanges();
        }
    }
}