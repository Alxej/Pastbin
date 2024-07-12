using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pastbin.DataAccess
{
    public class PastbinDbContext : DbContext
    {
        public PastbinDbContext(DbContextOptions<PastbinDbContext> options)
            : base(options)
        {
            
        }
    }
}
