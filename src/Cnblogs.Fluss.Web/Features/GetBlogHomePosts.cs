using System.Collections.Generic;
using Cnblogs.Fluss.Web.Models;
using MediatR;

namespace Cnblogs.Fluss.Web.Features
{
    public record GetBlogHomePosts : IRequest<IEnumerable<BlogPostViewModel>>
    {
        public GetBlogHomePosts(int pageIndex, int pageSize, int blogId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            BlogId = blogId;
        }

        public int BlogId { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
    }
}