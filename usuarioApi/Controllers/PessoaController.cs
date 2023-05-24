using Application.UseCase.Pessoa.Abstractions;
using Microsoft.AspNetCore.Mvc;
using usuarioApi.Shared.Entities;
using usuarioApi.UseCase.Pessoa.Models;

namespace usuarioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaUseCase _useCasePessoa;
        //private readonly IAtualizarDispositivo _useCaseAtualizarDispositivo;
        //private readonly IDeletarDispositivo _useCaseDeletarDispositivo;
        //private readonly IObterDispositivo _useCaseObterDispositivo;

        public PessoaController(IPessoaUseCase useCasePessoa/*, IDeletarDispositivo useCaseDeletarDispositivo, IObterDispositivo useCaseObterDispositivo, IAtualizarDispositivo useCaseAtualizarDispositivo*/)
        {
            _useCasePessoa = useCasePessoa;
            //_useCaseDeletarDispositivo = useCaseDeletarDispositivo;
            //_useCaseObterDispositivo = useCaseObterDispositivo;
            //_useCaseAtualizarDispositivo = useCaseAtualizarDispositivo;
        }

        [HttpGet("ObterTodos")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPessoas(CancellationToken cancellationToken)
        {
            return await _useCasePessoa.ExecuteAsyncObterUsuarios(cancellationToken);
        }

        [HttpPost]
        [Route("Criar")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarPessoa([FromBody] PessoaRequest request, CancellationToken cancellationToken)
        {
            return await _useCasePessoa.ExecuteAsyncCriarUsuario(request, cancellationToken);
        }
    }
}