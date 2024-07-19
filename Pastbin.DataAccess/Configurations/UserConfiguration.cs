using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pastbin.Core.Models;
using Pastbin.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasMaxLength(User.MAX_USERNAME_LENGTH)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(User.MAX_PASSWORD_LENGTH)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(User.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(User.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasMaxLength(User.MAX_NAME_LENGTH);
        }
            
    }
}
