using Microsoft.EntityFrameworkCore;
using trabajo_3.Entidades;
using trabajo_3.BLL;

namespace trabajo_3.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Entidades.db");
        }
    }
}
