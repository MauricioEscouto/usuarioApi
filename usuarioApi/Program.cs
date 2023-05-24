using System.Globalization;
using System.Text.Json.Serialization;
using usuarioApi.Modules;
using usuarioApi.Shared.Converts.Json;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region [ DateTime formato ]
CultureInfo culture = new CultureInfo("en-US");
culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
culture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
#endregion

services.AddUseCases();

services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    opt.JsonSerializerOptions.Converters.Add(new ValueTupleFactory());
});

services.AddSwaggerGen();

#region [ Build App ]
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "usuarioApi - v1"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion