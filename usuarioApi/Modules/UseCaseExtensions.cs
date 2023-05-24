using usuarioApi.Shared.Context;
using usuarioApi.Shared.Context.Abstractions;
using usuarioApi.UseCase.Pessoa;

namespace usuarioApi.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            return services
                .AddScoped<IDbConnectionFactory, DbConnectionFactory>()
                .PessoaUseCase();
        }

        public static IServiceCollection PessoaUseCase(this IServiceCollection services)
        {
            return services
                .AddPessoaUseCase();
        }
    }
}