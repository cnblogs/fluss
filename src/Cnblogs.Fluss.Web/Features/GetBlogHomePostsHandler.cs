using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cnblogs.Fluss.Domain;
using Cnblogs.Fluss.Infrastructure;
using Cnblogs.Fluss.Web.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cnblogs.Fluss.Web.Features
{
    public class GetBlogHomePostsHandler : IRequestHandler<GetBlogHomePosts, IEnumerable<BlogPostViewModel>>
    {
        private readonly IBlogSiteRepository _blogSiteRepository;

        public GetBlogHomePostsHandler(IBlogSiteRepository blogSiteRepository)
        {
            _blogSiteRepository = blogSiteRepository;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BlogPostViewModel>> Handle(GetBlogHomePosts request, CancellationToken cancellationToken)
        {
            return await _blogSiteRepository.NoTrackingQueryable
                .Where(b => b.Id == request.BlogId)
                .SelectMany(b => b.BlogPosts)
                .OrderByDescending(p => p.DateCreated)
                .Page(request.PageIndex, request.PageSize)
                .ProjectToType<BlogPostViewModel>()
                .ToListAsync(cancellationToken);
        }
    }
}