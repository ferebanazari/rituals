using Microsoft.EntityFrameworkCore;

namespace RitualsAPI.Models
{
    public class RitualsContext : DbContext
    {

        public RitualsContext(DbContextOptions<RitualsContext>
        options) : base(options) { }

        public DbSet<Matrett> Matrett { get; set; }

        public DbSet<Drikke> Drikke { get; set; }
        public DbSet<Dressinger> Dressinger { get; set; }

    }
}
