using Application.Shared.Enum;
using Dapper;
using usuarioApi.Shared.Constantes;
using usuarioApi.Shared.Context;
using usuarioApi.Shared.Context.Abstractions;
using usuarioApi.Shared.Entities;
using usuarioApi.UseCase.Pessoa.Models;
using usuarioApi.UseCase.Pessoa.Repositories.Abstractions;

namespace usuarioApi.UseCase.Pessoa.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly DbContext _dbContext;

        public PessoaRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _dbContext = _dbConnectionFactory.ObterContexto(AppSettingsConstantes.DB_RODOSOFT_ADM);
        }

        public async Task<List<PessoaRequest>> ObterPessoas(CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlQuery;

            IEnumerable<PessoaRequest> pessoas = await connection.QueryAsync<PessoaRequest>(querys.ObterPessoas(), cancellationToken);
            return pessoas.ToList();
        }

        public Task CriarPessoa(PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            if (pessoaRequest.EnumTipoDocumento == EnumTipoDocumento.CPF)
            {
                PessoaFisica pessoaFisica = new PessoaFisica(pessoaRequest);
                connection.Execute(querys.CriarPessoa(EnumTipoDocumento.CPF), pessoaFisica);
            }
            else if (pessoaRequest.EnumTipoDocumento == EnumTipoDocumento.CNPJ)
            {
                PessoaJuridica pessoaJuridica = new PessoaJuridica(pessoaRequest);
                connection.Execute(querys.CriarPessoa(EnumTipoDocumento.CNPJ), pessoaJuridica);
            }
            return Task.CompletedTask;
        }

        public Task AtualizarPessoa(int id, object Pessoa, CancellationToken cancellationToken)
        {
            //var connection = _dbContext.connection;
            //var querys = _dbContext.sqlCommand;

            //_logger.SalvarLog(idProjeto: dispositivo.IdProjeto, idRegistro: id, observacao: $"DISPOSITIVO REATIVADO ---- {dispositivo}");

            //connection.Execute(querys.ReativarDispositivo(id, dataBloqueio));
            return Task.CompletedTask;
        }

        public Task ExcluirPessoa(int id, CancellationToken cancellationToken)
        {
            //var connection = _dbContext.connection;
            //var querys = _dbContext.sqlCommand;

            //_logger.SalvarLog(idProjeto: dispositivo.IdProjeto, idRegistro: id, observacao: $"DISPOSITIVO REATIVADO ---- {dispositivo}");

            //connection.Execute(querys.ReativarDispositivo(id, dataBloqueio));
            return Task.CompletedTask;
        }
    }
}
