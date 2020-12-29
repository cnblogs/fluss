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
            builder.Property(p => p.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(p => p.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            builder.HasMany(p => p.ContentBlocks)
                .WithMany(p => p.BlogPosts)
                .UsingEntity<PostContent>(
                    j => j.HasOne(pc => pc.ContentBlock).WithMany().HasForeignKey(pc => pc.ContentBlockId),
                    j => j.HasOne(pc => pc.BlogPost).WithMany().HasForeignKey(pc => pc.PostId),
                    j =>
                    {
                        j.HasKey(pc => new { pc.PostId, pc.ContentBlockId });
                        j.Property(pc => pc.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.HasQueryFilter(pc => pc.IsExist);
                    });
        }
    }
}