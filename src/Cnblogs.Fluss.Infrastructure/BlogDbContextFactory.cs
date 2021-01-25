using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cnblogs.Fluss.Infrastructure
{
    /// <summary>
    /// Used for ef core migrations
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        /// <inheritdoc />
        public BlogDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>();
            options.UseSqlServer("Server=.;Database=Fluss;");
            return new BlogDbContext(options.Options, new Mediator(_ => new object()));
        }
    }
}