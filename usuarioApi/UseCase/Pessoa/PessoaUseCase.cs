using Application.UseCase.Pessoa.Abstractions;
using Microsoft.AspNetCore.Mvc;
using usuarioApi.UseCase.Pessoa.Models;
using usuarioApi.UseCase.Pessoa.Repositories.Abstractions;

namespace usuarioApi.UseCase.Pessoa
{
    public class PessoaUseCase : IPessoaUseCase
    {
        private readonly ControllerBase _controllerBase;
        private readonly IPessoaRepository _repository;
        private readonly ILogger _logger;

        public PessoaUseCase(IPessoaRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IActionResult> ExecuteAsyncCriarUsuario(PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            await _repository.CriarPessoa(pessoaRequest, cancellationToken);
            return _controllerBase.Ok("Sucesso na criação do usuário");
        }

        public async Task<IActionResult> ExecuteAsyncAtualizarUsuario(int id, PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            await _logger.SetRotina("BloquearDispositivo");
            Dispositivo dispositivo = await _repositoryObter.ObterDispositivoComId(id, cancellationToken);

            DateTime dataAtual = DateTime.Now;
            await _repository.BloquearDispositivo(id, dataAtual, dispositivo, cancellationToken);
            return _outputPort.Success("Dispositivo bloqueado com sucesso");
        }

        public async Task<IActionResult> ExecuteAsyncDeletarUsuario(int id, CancellationToken cancellationToken)
        {
            await _logger.SetRotina("ReativarDispositivo");
            Dispositivo dispositivo = await _repositoryObter.ObterDispositivoComId(id, cancellationToken);

            DateTime dataAtual = DateTime.Now;
            await _repository.ReativarDispositivo(id, dataAtual, dispositivo, cancellationToken);
            return _outputPort.Success("Dispositivo reativado com sucesso");
        }
    }
}
