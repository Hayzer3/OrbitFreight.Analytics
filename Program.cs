using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Obter a connection string e validar antes de configurar o DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada. Verifique appsettings.json, appsettings.Development.json, user-secrets ou variáveis de ambiente.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            Erro = "Ocorreu uma falha interna no servidor analítico.",
            Dica = "Verifique a comunicação com o banco de dados Oracle."
        });
    });
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
