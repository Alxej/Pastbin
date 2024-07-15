using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pastbin.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Url)
                .IsRequired();

            builder.Property(x => x.AddedAt)
                .IsRequired();

            builder.Property(x => x.UrlLifeCycle)
                .IsRequired();

            builder.HasOne(x => x.Post)
                .WithOne(x => x.Image)
                .HasForeignKey("ImageEntity", "ImageId");
        }
    }
}
