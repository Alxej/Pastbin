using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pastbin.DataAccess.Entites;
using Pastbin.Core.Models;
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
                .HasMaxLength(Post.MAX_HEADER_LENGTH)
                .IsRequired();

            builder.Property(x => x.AuthorId)
                .IsRequired();

            builder.Property(x => x.ImageId)
                .IsRequired();

            builder.Property(x => x.TextBlockId)
                .IsRequired();
        }
    }
}
