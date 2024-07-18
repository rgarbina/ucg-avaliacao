using UCG.Service.Avaliacao.Models;

namespace ucg_avaliacao.Server.ViewModel
{
    public class PessoaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        public ICollection<PessoaViewModel> Dependentes { get; set; }
    }
}
