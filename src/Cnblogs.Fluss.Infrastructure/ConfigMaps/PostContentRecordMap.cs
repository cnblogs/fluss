using Cnblogs.Fluss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnblogs.Fluss.Infrastructure.ConfigMaps
{
    public class PostContentRecordMap : IEntityTypeConfiguration<PostContentRecord>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<PostContentRecord> builder)
        {
            builder.ToTable("blog_post_content").HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(p => p.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasQueryFilter(p => p.IsExist);
        }
    }
}