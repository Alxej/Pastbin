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
    }
}
