using Application.Shared.Enum;
using usuarioApi.Shared.Entities.Abstractions;
using usuarioApi.UseCase.Pessoa.Models;

namespace usuarioApi.Shared.Entities
{
    public class PessoaFisica : IPessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public EnumTipoDocumento EnumTipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public EnumGenero EnumGenero { get; set; }
        public DateTime DataNascimento { get; set; }

        public PessoaFisica(PessoaRequest pessoaRequest) { 
            this.Nome = pessoaRequest.Nome;
            this.EnumTipoDocumento = pessoaRequest.EnumTipoDocumento;
            this.Documento = pessoaRequest.Documento;
            this.Telefone = pessoaRequest.Telefone;
            this.Endereco = pessoaRequest.Endereco;
            this.EnumGenero = pessoaRequest.EnumGenero;
            this.DataNascimento = pessoaRequest.DataNascimento;
        }   
    }
}