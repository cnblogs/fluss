using Cnblogs.Fluss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnblogs.Fluss.Infrastructure.ConfigMaps
{
    public class BlogSiteMap : IEntityTypeConfiguration<BlogSite>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<BlogSite> builder)
        {
            builder.ToTable("blog_site").HasKey(b => b.Id);
            builder.HasQueryFilter(b => b.IsExist);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(b => b.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            builder.HasMany(b => b.BlogPosts).WithOne(p => p.BlogSite).HasForeignKey(p => p.BlogId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(b => b.ContentBlocks).WithOne(c => c.BlogSite).HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}