using System.ComponentModel.DataAnnotations.Schema;

namespace UCG.Service.Avaliacao.Models
{
    public class DependenteModel
    {
        public Guid IdPessoa { get; set; }
        public Guid IdDependente { get; set; }

        [NotMapped]
        public PessoaModel Pessoa { get; set; }
        [NotMapped]
        public PessoaModel Dependente { get; set; }
    }
}
