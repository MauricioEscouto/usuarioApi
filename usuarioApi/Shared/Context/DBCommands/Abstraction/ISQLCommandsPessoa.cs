using Application.Shared.Enum;

namespace usuarioApi.Shared.Context.DBCommands.Abstraction
{
    public partial interface ISQLCommands
    {
        public string CriarPessoa(EnumTipoDocumento enumTipoDocumento);
        public string AtualizarPessoa(int id);
        public string DeletarPessoa(int id);
    }
}