using Microsoft.EntityFrameworkCore;
using Net.UI.Models.Entity;

namespace Net.UI.Data
{
    public class NetDbContext : DbContext
    {
        public NetDbContext(DbContextOptions<NetDbContext> options) : base(options)
        {
        }



        public DbSet<AppUser> AppUsers { get; set; }


        public DbSet<Order> Orders { get; set; }


        public DbSet<Adress> Adresses { get; set; }


        

    }
}
