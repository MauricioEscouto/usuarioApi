namespace Application.Shared.Enum
{
    public class EnumDbConexao
    {
        public enum EnumTipoBanco
        {
            MySQL,
            SQLServer,
            Oracle,
            SQLite
        }

        public enum EnumTipoAmbiente
        {
            Producao = 1,
            Homologacao = 2
        }
    }
}
