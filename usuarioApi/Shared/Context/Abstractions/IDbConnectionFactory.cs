namespace usuarioApi.Shared.Context.Abstractions
{
    public interface IDbConnectionFactory
    {
        DbContext ObterContexto(string AppSettingsSection);
    }
}