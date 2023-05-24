using usuarioApi.Shared.Context.DBQuerys.Abstraction;

namespace usuarioApi.Shared.Context.DBQuerys.Implementations
{
    public partial class MySQLQuerys : ISQLQuerys
    {
        public string ObterPessoas()
        {
            string query = $@"SELECT * FROM usuarios";

            return query;
        }
    }
}