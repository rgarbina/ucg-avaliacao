namespace UCG.Service.Avaliacao.Models
{
    public class PessoaModel
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        public ICollection<DependenteModel> Dependentes { get; set; }
    }
}
