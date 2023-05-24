using Application.UseCase.Pessoa.Abstractions;
using usuarioApi.UseCase.Pessoa.Repositories;
using usuarioApi.UseCase.Pessoa.Repositories.Abstractions;

namespace usuarioApi.UseCase.Pessoa
{
    public static class PessoaInjectionsDependencies
    {
        public static IServiceCollection AddPessoaUseCase(this IServiceCollection services)
        {
            return services
                .AddScoped<IPessoaRepository, PessoaRepository>()
                .AddScoped<IPessoaUseCase, PessoaUseCase>();
        }
    }
}