using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace usuarioApi.Modules
{
    public static class SwaggerConfigExtensions
    {
        public static WebApplication ConfigureSwaggerUI(this WebApplication app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(o =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    o.SwaggerEndpoint($"/swagger/swagger.json", $"usuarioApi - {description.GroupName.ToUpper()}");
                }
            });
            return app;
        }
    }
}