using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using UCG.Service.Avaliacao.Models;

namespace UCG.Service.Avaliacao.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.ToTable("pessoa", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Nascimento).IsRequired();
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.RG).HasMaxLength(8);

            builder.HasMany(h => h.Dependentes).WithOne(d => d.Pessoa).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
