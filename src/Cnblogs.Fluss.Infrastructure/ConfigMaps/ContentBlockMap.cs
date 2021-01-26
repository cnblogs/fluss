using Cnblogs.Fluss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnblogs.Fluss.Infrastructure.ConfigMaps
{
    public class ContentBlockMap : IEntityTypeConfiguration<ContentBlock>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<ContentBlock> builder)
        {
            builder.ToTable("blog_content_block").HasKey(b => b.Id);
            builder.HasQueryFilter(b => b.IsExist);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(b => b.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            builder.HasMany(b => b.RenderConfigs).WithOne()
                .HasForeignKey(c => c.ContentBlockId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}