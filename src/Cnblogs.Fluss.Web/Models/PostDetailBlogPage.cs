namespace Cnblogs.Fluss.Web.Models
{
    public class PostDetailBlogPage : BaseBlogPage
    {
        public PostDetailBlogPage(BlogPostDetailViewModel post)
        {
            Post = post;
        }

        public BlogPostDetailViewModel Post { get; }
    }
}