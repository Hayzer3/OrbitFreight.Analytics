using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5165");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("*")); 
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada. Verifique o appsettings.json.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine($" {DateTime.Now:HH:mm:ss} | {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");
    await next();
    Console.WriteLine($" {DateTime.Now:HH:mm:ss} | Status: {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERRO: {ex.Message}");
        Console.WriteLine($"Stack: {ex.StackTrace}");

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var errorResponse = new
        {
            Erro = "Ocorreu uma falha interna no servidor.",
            Detalhe = ex.Message,
            Dica = "Verifique a comunicação com o banco de dados Oracle e se as tabelas existem."
        };

        await context.Response.WriteAsJsonAsync(errorResponse);
    }
});

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrbiFreight Analytics API");
        c.RoutePrefix = "swagger";
    });
}


app.UseAuthorization();
app.MapControllers();

Console.WriteLine(" API OrbiFreight Analytics rodando em http://0.0.0.0:5165");
Console.WriteLine($"Swagger disponível em: http://localhost:5165/swagger");

app.Run();