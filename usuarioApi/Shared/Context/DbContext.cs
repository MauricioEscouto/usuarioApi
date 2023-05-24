using System.Data;
using usuarioApi.Shared.Context.DBCommands.Abstraction;
using usuarioApi.Shared.Context.DBQuerys.Abstraction;

namespace usuarioApi.Shared.Context
{
    public class DbContext
    {
        public IDbConnection connection;
        public ISQLQuerys sqlQuery;
        public ISQLCommands sqlCommand;
        public DbContext(IDbConnection connection, ISQLQuerys siapQuery, ISQLCommands siapCommand)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(DbContext.connection));
            this.sqlQuery = siapQuery ?? throw new ArgumentNullException(nameof(sqlQuery));
            this.sqlCommand = siapCommand ?? throw new ArgumentNullException(nameof(sqlCommand));
        }
    }
}