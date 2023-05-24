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
        private readonly ILogger _logger;

        public PessoaRepository(IDbConnectionFactory dbConnectionFactory, ILogger logger)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _dbContext = _dbConnectionFactory.ObterContexto(AppSettingsConstantes.DB_RODOSOFT_ADM);
            _logger = logger;
        }
        
        public Task CriarPessoa(PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            if (pessoaRequest.EnumTipoDocumento == EnumTipoDocumento.CPF)
            {
                PessoaFisica pessoaFisica = new PessoaFisica(pessoaRequest);
                connection.Execute(querys.CriarDispositivo(), pessoaFisica);
            }
            else if (pessoaRequest.EnumTipoDocumento == EnumTipoDocumento.CNPJ)
            {
                PessoaJuridica pessoaJuridica = new PessoaJuridica(pessoaRequest);
                connection.Execute(querys.CriarDispositivo(), pessoaJuridica);
            }
            return Task.CompletedTask;
        }

        public Task AtualizarPessoa(int id, object Pessoa, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            _logger.SalvarLog(idProjeto: dispositivo.IdProjeto, idRegistro: id, observacao: $"DISPOSITIVO REATIVADO ---- {dispositivo}");

            connection.Execute(querys.ReativarDispositivo(id, dataBloqueio));
            return Task.CompletedTask;
        }

        public Task ExcluirPessoa(int id, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            _logger.SalvarLog(idProjeto: dispositivo.IdProjeto, idRegistro: id, observacao: $"DISPOSITIVO REATIVADO ---- {dispositivo}");

            connection.Execute(querys.ReativarDispositivo(id, dataBloqueio));
            return Task.CompletedTask;
        }
    }
}
