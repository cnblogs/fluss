using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cnblogs.Fluss.Domain;
using Cnblogs.Fluss.Web.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cnblogs.Fluss.Web.Features
{
    public class GetBlogSiteHandler : IRequestHandler<GetBlogSite, BlogSiteViewModel>
    {
        private readonly IBlogSiteRepository _blogSiteRepository;

        public GetBlogSiteHandler(IBlogSiteRepository blogSiteRepository)
        {
            _blogSiteRepository = blogSiteRepository;
        }

        /// <inheritdoc />
        public async Task<BlogSiteViewModel> Handle(GetBlogSite request, CancellationToken cancellationToken)
        {
            return await _blogSiteRepository.NoTrackingQueryable
                .Where(b => b.Id == request.BlogId)
                .ProjectToType<BlogSiteViewModel>()
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}