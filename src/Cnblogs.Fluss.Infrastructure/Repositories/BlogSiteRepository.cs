using Cnblogs.Fluss.Domain;
using Cnblogs.Fluss.Domain.Entities;

namespace Cnblogs.Fluss.Infrastructure.Repositories
{
    public class BlogSiteRepository : BaseRepository<BlogDbContext, BlogSite, long>, IBlogSiteRepository
    {
        public BlogSiteRepository(BlogDbContext context)
            : base(context)
        {
        }
    }
}