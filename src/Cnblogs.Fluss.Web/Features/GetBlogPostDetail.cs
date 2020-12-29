using Cnblogs.Fluss.Web.Models;
using MediatR;

namespace Cnblogs.Fluss.Web.Features
{
    public class GetBlogPostDetail : IRequest<BlogPostDetailViewModel>
    {
        public GetBlogPostDetail(long blogId, long postId)
        {
            BlogId = blogId;
            PostId = postId;
        }

        public long BlogId { get; }
        public long PostId { get; }
    }
}