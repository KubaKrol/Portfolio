using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<AppUserRole> Roles { get; set; } 
        public DbSet<Email> Emails { get; set; }
    }
}