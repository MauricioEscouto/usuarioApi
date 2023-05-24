using Application.Shared.Enum;

namespace usuarioApi.UseCase.Pessoa.Models
{
    public class PessoaRequest
    {
        public string? Nome { get; set; }
        public EnumTipoDocumento EnumTipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public EnumGenero EnumGenero { get; set; }
        public DateTime DataNascimento { get; set; }
        public double ValorCapitalSocial { get; set; }
        public DateTime DataFundacao { get; set; }
    }
}