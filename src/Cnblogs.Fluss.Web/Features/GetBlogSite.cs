using Cnblogs.Fluss.Web.Models;
using MediatR;

namespace Cnblogs.Fluss.Web.Features
{
    public class GetBlogSite : IRequest<BlogSiteViewModel>
    {
        public GetBlogSite(int blogId)
        {
            BlogId = blogId;
        }

        public int BlogId { get; }
    }
}