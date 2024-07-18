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
            return await _dbContext.Pessoa.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<DependenteModel>> AdicionarEditarDependente(PessoaModel paramPessoaModel)
        {
            if (paramPessoaModel.Dependentes.Any())
            {
                await RemoverDependente(paramPessoaModel.Id);

                foreach (var dependente in paramPessoaModel.Dependentes)
                {
                    _dbContext.Dependente.Add(new DependenteModel
                    {
                        IdPessoa = paramPessoaModel.Id,
                        IdDependente = dependente.IdPessoa
                    });
                }

                await _dbContext.SaveChangesAsync();
            }

            return paramPessoaModel.Dependentes;
        }

        public async Task<PessoaModel> CadastrarPessoa(PessoaModel paramPessoaModel)
        {
            await _dbContext.Pessoa.AddAsync(paramPessoaModel);
            await _dbContext.SaveChangesAsync();
            await AdicionarEditarDependente(paramPessoaModel);

            return paramPessoaModel;
        }

        public async Task<PessoaModel> EditarPessoa(PessoaModel paramPessoaModel)
        {
            var oPessoa = await BuscarPorId(paramPessoaModel.Id);

            oPessoa.Nome = paramPessoaModel.Nome;
            oPessoa.Nascimento = paramPessoaModel.Nascimento;
            oPessoa.CPF = paramPessoaModel.CPF;
            oPessoa.RG = paramPessoaModel.RG;
            await AdicionarEditarDependente(paramPessoaModel);

            await _dbContext.SaveChangesAsync();

            return paramPessoaModel;
        }

        public async Task<PessoaModel> RemoverPessoa(Guid id)
        {
            var oPessoa = await BuscarPorId(id);

            _dbContext.Pessoa.Remove(oPessoa);
            await _dbContext.SaveChangesAsync();

            return oPessoa;
        }

        public async Task<List<DependenteModel>> RemoverDependente(Guid idPessoa)
        {
            var listDependentes = _dbContext.Dependente.Where(w => w.IdPessoa == idPessoa);
            _dbContext.Dependente.RemoveRange(listDependentes);
            await RemoverDependente(idPessoa);
            await _dbContext.SaveChangesAsync();

            return await listDependentes.ToListAsync();
        }
    }
}
