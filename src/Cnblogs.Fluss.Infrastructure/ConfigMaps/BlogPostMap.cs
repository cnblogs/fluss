using Cnblogs.Fluss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnblogs.Fluss.Infrastructure.ConfigMaps
{
    public class BlogPostMap : IEntityTypeConfiguration<BlogPost>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("blog_post").HasKey(p => p.Id);
            builder.HasQueryFilter(b => b.IsExist);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(p => p.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            builder.HasMany(p => p.ContentRecords).WithOne(c => c.BlogPost).HasForeignKey(c => c.PostId);
        }
    }
}