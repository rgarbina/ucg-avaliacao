namespace UCG.Service.Avaliacao.Models
{
    public class DependenteModel
    {
        public Guid IdPessoa { get; set; }
        public Guid IdDependente { get; set; }

        public PessoaModel Pessoa { get; set; }
        public PessoaModel Dependente { get; set; }
    }
}
