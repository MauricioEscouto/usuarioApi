using Application.Shared.Enum;

namespace usuarioApi.Shared.Entities.Abstractions
{
    public interface IPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoDocumento EnumTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
