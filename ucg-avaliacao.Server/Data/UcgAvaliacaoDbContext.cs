using Microsoft.EntityFrameworkCore;
using UCG.Service.Avaliacao.Data.Map;
using UCG.Service.Avaliacao.Models;

namespace UCG.Service.Avaliacao.Data
{
    public class UcgAvaliacaoDbContext : DbContext
    {
        public UcgAvaliacaoDbContext(DbContextOptions<UcgAvaliacaoDbContext> options)
            : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<DependenteModel> Dependente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
