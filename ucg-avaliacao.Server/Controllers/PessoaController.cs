using Microsoft.AspNetCore.Mvc;
using UCG.Service.Avaliacao.Models;
using UCG.Service.Avaliacao.Repositorios.Interfaces;

namespace UCG.Service.Avaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaModel>> BuscarPorId(Guid id)
        {
            var r = await _pessoaRepositorio.BuscarPorId(id);
            return Ok(r);
        }

        [HttpGet("todas")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodasAsPessoas()
        {
            var r = await _pessoaRepositorio.BuscarTodasAsPessoas();
            return Ok(r);
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<List<PessoaModel>>> CadastrarPessoa(PessoaModel pessoa)
        {
            var r = await _pessoaRepositorio.CadastrarPessoa(pessoa);
            return Ok(r);
        }

        [HttpPost("editar")]
        public async Task<ActionResult<List<PessoaModel>>> EditarPessoa(PessoaModel pessoa)
        {
            var r = await _pessoaRepositorio.EditarPessoa(pessoa);
            return Ok(r);
        }

        [HttpPost("remover")]
        public async Task<ActionResult<List<PessoaModel>>> RemoverPessoa(Guid id)
        {
            var r = await _pessoaRepositorio.RemoverPessoa(id);
            return Ok(r);
        }
    }
}
