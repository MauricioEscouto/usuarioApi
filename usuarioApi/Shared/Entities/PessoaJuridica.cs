using Application.Shared.Enum;
using usuarioApi.Shared.Entities.Abstractions;
using usuarioApi.UseCase.Pessoa.Models;

namespace usuarioApi.Shared.Entities
{
    public class PessoaJuridica : IPessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public EnumTipoDocumento EnumTipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public  double ValorCapitalSocial { get; set; }
        public DateTime DataFundacao { get; set; }

        public PessoaJuridica(PessoaRequest pessoaRequest)
        {
            this.Nome = pessoaRequest.Nome;
            this.EnumTipoDocumento = pessoaRequest.EnumTipoDocumento;
            this.Documento = pessoaRequest.Documento;
            this.Telefone = pessoaRequest.Telefone;
            this.Endereco = pessoaRequest.Endereco;
            this.ValorCapitalSocial = pessoaRequest.ValorCapitalSocial;
            this.DataFundacao = pessoaRequest.DataFundacao;
        }
    }
}