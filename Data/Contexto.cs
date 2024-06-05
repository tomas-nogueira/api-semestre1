using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }    
        public DbSet<AnimalsModel> Animals { get; set; }
        public DbSet<ObservacoesModel> Observacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AnimalsMap());
            modelBuilder.ApplyConfiguration(new ObservacoesMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
