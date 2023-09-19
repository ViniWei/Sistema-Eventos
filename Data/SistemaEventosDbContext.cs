using Microsoft.EntityFrameworkCore;
using Sistema_Eventos.Models;

namespace Sistema_Eventos.Data
{
    public class SistemaEventosDbContext : DbContext
    {
        public DbSet<Atuante>? Atuante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=goon-laptop03\\SQLEXPRESS;Initial Catalog=SistemaEventosDb;Integrated Security=True; trustServerCertificate=true");
        }
    }
}
