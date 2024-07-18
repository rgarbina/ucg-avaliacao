using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        }
    }
}
