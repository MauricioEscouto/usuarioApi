using Microsoft.AspNetCore.Mvc;
using usuarioApi.UseCase.Pessoa.Models;

namespace Application.UseCase.Pessoa.Abstractions
{
    public interface IPessoaUseCase
    {
        Task<IActionResult> ExecuteAsyncCriarUsuario(PessoaRequest pessoaRequest, CancellationToken cancellationToken);
        Task<IActionResult> ExecuteAsyncAtualizarUsuario(int id, PessoaRequest pessoaRequest, CancellationToken cancellationToken);
        Task<IActionResult> ExecuteAsyncDeletarUsuario(int id, CancellationToken cancellationToken);
    }
}