using static Application.Shared.Enum.EnumDbConexao;

namespace usuarioApi.Models
{
    public class AppSettingsDbConfiguracao
    {
        public EnumTipoBanco TipoBanco { get; set; }
        public string? ConnectionString { get; set; }
        public EnumTipoAmbiente TipoAmbiente { get; set; }
    }
}