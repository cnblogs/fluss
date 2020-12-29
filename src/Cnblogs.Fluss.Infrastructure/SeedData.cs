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
            var body = new ContentBlock() { BlogId = blog.Id, Content = "<p>博文内容块之间可以相互引用</p>" };
            var post = new BlogPost
            {
                Title = "Fluss 是一个开源的博客引擎",
                Description = "它基于 .NET，能够保存和展示您的工作总结，技术收获，心得体会等。更有出色的块引用功能，更好的帮助您维护多篇文章内的相同内容。",
                AutoDesc = "它基于 .NET，能够保存和展示您的工作总结，技术收获，心得体会等。更有出色的块引用功能，更好的帮助您维护多篇文章内的相同内容。",
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