using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cnblogs.Fluss.Domain.Abstractions;
using Cnblogs.Fluss.Infrastructure.ConfigMaps;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cnblogs.Fluss.Infrastructure
{
    public class BlogDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public BlogDbContext(DbContextOptions<BlogDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogSiteMap());
            modelBuilder.ApplyConfiguration(new BlogPostMap());
            modelBuilder.ApplyConfiguration(new ContentBlockMap());
            modelBuilder.ApplyConfiguration(new ContentRenderConfigMap());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(
                        p => p.PropertyType == typeof(DateTimeOffset)
                             || p.PropertyType == typeof(DateTimeOffset?));
                    foreach (var property in properties)
                    {
                        modelBuilder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion(new DateTimeOffsetToBinaryConverter());
                    }
                }
            }
        }

        /// <inheritdoc />
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            return await SaveChangesAsync(cancellationToken) > 0;
        }
    }
}