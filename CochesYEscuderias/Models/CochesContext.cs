using Microsoft.EntityFrameworkCore;

namespace CochesYEscuderias.Models
{
    public class CochesContext :DbContext
    {
        public DbSet<Coche> Coches { get; set; }
        public DbSet<Escuderia> Escuderias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server=(localdb)\\MSSQLLocalDB;database=CochesYEscuderias;Integrated Security=True");
        }
    }
}
