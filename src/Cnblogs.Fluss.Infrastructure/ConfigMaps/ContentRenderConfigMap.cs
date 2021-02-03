using Cnblogs.Fluss.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnblogs.Fluss.Infrastructure.ConfigMaps
{
    public class ContentRenderConfigMap : IEntityTypeConfiguration<ContentRenderConfig>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<ContentRenderConfig> builder)
        {
            builder.ToTable("blog_content_render_config").HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(r => r.DateUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnUpdate();
            builder.HasQueryFilter(r => r.IsExist);
        }
    }
}