using InlamningNet.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InlamningNet.Data
{
    public class NetDbcontext : DbContext
    {
        public NetDbcontext(DbContextOptions<NetDbcontext> dbContextOptions) : base(dbContextOptions)
        {

        }


        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
