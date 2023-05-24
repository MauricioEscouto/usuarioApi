using Application.UseCase.Pessoa.Abstractions;
using Microsoft.AspNetCore.Mvc;
using usuarioApi.UseCase.Pessoa.Models;
using usuarioApi.UseCase.Pessoa.Repositories.Abstractions;

namespace usuarioApi.UseCase.Pessoa
{
    public class PessoaUseCase : ControllerBase, IPessoaUseCase
    {
        private readonly IPessoaRepository _repository;

        public PessoaUseCase(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> ExecuteAsyncObterUsuarios(CancellationToken cancellationToken)
        {
            List<PessoaRequest> pessoaRequests = await _repository.ObterPessoas(cancellationToken);
            return Ok(pessoaRequests);
        }

        public async Task<IActionResult> ExecuteAsyncCriarUsuario(PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            await _repository.CriarPessoa(pessoaRequest, cancellationToken);
            return Ok("Sucesso na criação do usuário");
        }

        public Task<IActionResult> ExecuteAsyncAtualizarUsuario(int id, PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> ExecuteAsyncDeletarUsuario(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
