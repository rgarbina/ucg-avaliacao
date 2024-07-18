using UCG.Service.Avaliacao.Models;

namespace UCG.Service.Avaliacao.Repositorios.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<PessoaModel?> BuscarPorId(Guid id);
        Task<List<PessoaModel>> BuscarTodasAsPessoas();
    }
}
