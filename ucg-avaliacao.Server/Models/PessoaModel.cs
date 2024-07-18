using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UCG.Service.Avaliacao.Models
{
    public class PessoaModel
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        [NotMapped]
        public string[] NomeDependentes { get; set; } = null;

        public virtual ICollection<DependenteModel> Dependentes { get; set; }
    }
}
