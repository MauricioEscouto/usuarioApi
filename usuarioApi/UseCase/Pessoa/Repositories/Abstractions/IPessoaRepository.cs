﻿using usuarioApi.UseCase.Pessoa.Models;

namespace usuarioApi.UseCase.Pessoa.Repositories.Abstractions
{
    public interface IPessoaRepository
    {
        Task<List<PessoaRequest>> ObterPessoas(CancellationToken cancellationToken);
        Task CriarPessoa(PessoaRequest pessoaRequest, CancellationToken cancellationToken);
        Task AtualizarPessoa(int id, object Pessoa, CancellationToken cancellationToken);
        Task ExcluirPessoa(int id, CancellationToken cancellationToken);
    }
}