using CodeFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Data
{
    public class SiliconDbContext : DbContext
    {
        public SiliconDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Silicon> Silicons { get; set; }
    }
}
