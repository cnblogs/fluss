using Cnblogs.Fluss.Domain.Abstractions;
using Cnblogs.Fluss.Domain.Entities;

namespace Cnblogs.Fluss.Domain
{
    public interface IBlogSiteRepository : IRepository<BlogSite, long>
    {
    }
}