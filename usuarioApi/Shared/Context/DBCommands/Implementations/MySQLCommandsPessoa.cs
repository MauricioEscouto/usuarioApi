using Application.Shared.Enum;
using usuarioApi.Shared.Context.DBCommands.Abstraction;

namespace usuarioApi.Shared.Context.DBCommands.Implementations
{
    public class MySQLCommands : ISQLCommands
    {
        public string CriarPessoa(EnumTipoDocumento enumTipoDocumento)
        {
            string command = $@"INSERT INTO usuarios
                                ( Nome
                                , TipoDocumento
                                , Documento
                                , Telefone
                                , Endereco
                                {(enumTipoDocumento == EnumTipoDocumento.CPF ? ",Genero" : string.Empty)}
                                {(enumTipoDocumento == EnumTipoDocumento.CPF ? ",DataNascimento" : string.Empty)}
                                {(enumTipoDocumento == EnumTipoDocumento.CNPJ ? ",DataFundacao" : string.Empty)}
                                {(enumTipoDocumento == EnumTipoDocumento.CNPJ ? ",ValorCapitalSocial" : string.Empty)}
                                )

                                VALUES 

                                ( @Nome
                                , @EnumTipoDocumento
                                , @Documento
                                , @Telefone
                                , @Endereco
                                {(enumTipoDocumento == EnumTipoDocumento.CPF ? ",@EnumGenero" : string.Empty)}
                                {(enumTipoDocumento == EnumTipoDocumento.CPF ? ",@DataNascimento" : string.Empty)}
                                {(enumTipoDocumento == EnumTipoDocumento.CNPJ ? ",@ValorCapitalSocial" : string.Empty)}
                                {(enumTipoDocumento == EnumTipoDocumento.CNPJ ? ",ValorCapitalSocial" : string.Empty)}
                                )";
            return command;
        }

        public string AtualizarPessoa(int id)
        {
            throw new NotImplementedException();
        }

        public string DeletarPessoa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
