using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;
using UCG.Service.Avaliacao.Models;

namespace UCG.Service.Avaliacao.Data.Map
{
    public class DependenteMap : IEntityTypeConfiguration<DependenteModel>
    {
        public void Configure(EntityTypeBuilder<DependenteModel> builder)
        {
            builder.ToTable("dependente", "dbo");
            builder.HasKey(x => new { x.IdPessoa, x.IdDependente });
            builder.HasOne(x => x.Pessoa).WithMany(x => x.Dependentes).HasForeignKey(x=> x.IdDependente);
        }
    }
}
