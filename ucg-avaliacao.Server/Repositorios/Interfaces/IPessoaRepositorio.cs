using UCG.Service.Avaliacao.Models;

namespace UCG.Service.Avaliacao.Repositorios.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<PessoaModel?> BuscarPorId(Guid id);
        Task<List<PessoaModel>> BuscarTodasAsPessoas();
        Task<PessoaModel> CadastrarPessoa(PessoaModel paramPessoaModel);
        Task<PessoaModel> EditarPessoa(PessoaModel paramPessoaModel);
        Task<PessoaModel?> RemoverPessoa(Guid id);
    }
}
