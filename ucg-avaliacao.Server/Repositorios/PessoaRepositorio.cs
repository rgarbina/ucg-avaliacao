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

        public async Task<PessoaModel?> BuscarPorIdDetalhe(Guid id)
        {
            var detalhePessoa = await _dbContext.Pessoa.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var listDependentes = await _dbContext.Dependente.Where(w => w.IdPessoa == id).ToListAsync();

            if (listDependentes.Any())
            {
                foreach (var dependente in listDependentes)
                {
                    dependente.Dependente = await _dbContext.Pessoa.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dependente.IdDependente);
                }

                detalhePessoa.NomeDependentes = listDependentes.Select(s => s.Dependente.Nome).ToArray();
            }

            return detalhePessoa;
        }

        public async Task<List<PessoaModel>> BuscarTodasAsPessoas()
        {
            return await _dbContext.Pessoa.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<DependenteModel>> AdicionarEditarDependente(Guid idPessoa, ICollection<DependenteModel> collectionDependentes)
        {
            if (collectionDependentes.Any())
            {
                var arrayDependentes = collectionDependentes.Select(s => s.IdDependente).ToArray();

                await RemoverDependente(idPessoa);

                foreach (var dependente in arrayDependentes)
                {
                    _dbContext.Dependente.Add(new DependenteModel
                    {
                        IdPessoa = idPessoa,
                        IdDependente = dependente
                    });
                }

                await _dbContext.SaveChangesAsync();
            }

            return collectionDependentes;
        }

        public async Task<PessoaModel> CadastrarPessoa(PessoaModel paramPessoaModel)
        {
            var oPessoa = new PessoaModel()
            {
                Nome = paramPessoaModel.Nome,
                Nascimento = paramPessoaModel.Nascimento,
                CPF = paramPessoaModel.CPF,
                RG = paramPessoaModel.RG
            };

            await _dbContext.Pessoa.AddAsync(oPessoa);
            await _dbContext.SaveChangesAsync();
            await AdicionarEditarDependente(oPessoa.Id, paramPessoaModel.Dependentes);

            return paramPessoaModel;
        }

        public async Task<PessoaModel> EditarPessoa(PessoaModel paramPessoaModel)
        {
            var oPessoa = await BuscarPorId(paramPessoaModel.Id);

            oPessoa.Nome = paramPessoaModel.Nome;
            oPessoa.Nascimento = paramPessoaModel.Nascimento;
            oPessoa.CPF = paramPessoaModel.CPF;
            oPessoa.RG = paramPessoaModel.RG;
            await AdicionarEditarDependente(oPessoa.Id, paramPessoaModel.Dependentes);

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
            await _dbContext.SaveChangesAsync();

            return await listDependentes.ToListAsync();
        }
    }
}
