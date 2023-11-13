using Microsoft.EntityFrameworkCore;
using Sistema_Eventos.Models;


namespace Sistema_Eventos.Data
{
    public class SistemaEventosDbContext : DbContext
    {
        public DbSet<Atuante>? Atuante { get; set; }
        public DbSet<Organizador>? Organizador { get; set; }
        public DbSet<Produto>? Produto { get; set; }
        public DbSet<Kit>? Kit { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Plano>? Plano { get; set; }
        public DbSet<Evento>? Evento { get; set; }
        public DbSet<Ingresso>? Ingresso { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=SistemaEventos.db;Cache=Shared;");
        }
    }
}
