using MySql.Data.MySqlClient;
using System.Data;
using usuarioApi.Models;
using usuarioApi.Shared.Context.Abstractions;
using usuarioApi.Shared.Context.DBCommands.Abstraction;
using usuarioApi.Shared.Context.DBCommands.Implementations;
using usuarioApi.Shared.Context.DBQuerys.Abstraction;
using usuarioApi.Shared.Context.DBQuerys.Implementations;
using static Application.Shared.Enum.EnumDbConexao;

namespace usuarioApi.Shared.Context
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContext ObterContexto(string AppSettingsSection)
        {
            IConfigurationSection configuracaoSessao = _configuration.GetSection(AppSettingsSection);
            AppSettingsDbConfiguracao configSessao = new();
            configuracaoSessao.Bind(configSessao);

            IDbConnection dbConnection;
            ISQLCommands sqlCommands;
            ISQLQuerys sqlQuerys;

            switch (configSessao.TipoBanco)
            {
                case EnumTipoBanco.MySQL:
                    dbConnection = new MySqlConnection(configSessao.ConnectionString);
                    sqlQuerys = new MySQLQuerys();
                    sqlCommands = new MySQLCommands();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new DbContext(dbConnection, sqlQuerys, sqlCommands);
        }
    }
}
