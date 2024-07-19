using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pastbin.DataAccess.Entites;

namespace Pastbin.DataAccess
{
    public class PastbinDbContext : DbContext
    {
        public PastbinDbContext(DbContextOptions<PastbinDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<TextBlockEntity> TextBlocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.Id);

            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.Image)
                .WithOne(e => e.Post)
                .HasForeignKey<PostEntity>(e => e.ImageId)
                .IsRequired();

            modelBuilder.Entity<PostEntity>()
                .HasOne(e => e.Text)
                .WithOne(e => e.Post)
                .HasForeignKey<PostEntity>(e => e.TextBlockId)
                .IsRequired();

        }
    }
}
