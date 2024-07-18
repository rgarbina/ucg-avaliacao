using Microsoft.EntityFrameworkCore;
using UCG.Service.Avaliacao.Models;
using UCG.Service.Avaliacao.Repositorios.Interfaces;
using UCG.Service.Avaliacao.Data;

namespace ucg_avaliacao.Server.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly UcgAvaliacaoDbContext _dbContext;
        public PessoaRepositorio(UcgAvaliacaoDbContext ucgAvaliacaoDbContext)
        {
            _dbContext = ucgAvaliacaoDbContext;
        }

        public async Task<PessoaModel?> BuscarPorId(Guid id) => await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<PessoaModel>> BuscarTodasAsPessoas()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }
    }
}
