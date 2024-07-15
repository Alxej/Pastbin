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
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Header)
                .IsRequired();

            builder.Property(x => x.AuthorId)
                .IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ImageId)
                .IsRequired();
            builder.HasOne(x => x.Image)
                .WithOne(x => x.Post)
                .HasForeignKey("ImageEntity", "ImageId")
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.TextBlockId)
                .IsRequired();
            builder.HasOne(x => x.Text)
                .WithOne(x => x.Post)
                .HasForeignKey("TextBlockEntity", "TextBlockId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
