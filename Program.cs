using Microsoft.EntityFrameworkCore;
using OrbiFreight.Analytics.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Adicionando CORS para resolver o erro "Failed to fetch"
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configuração da Connection String e DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada. Verifique o appsettings.json.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

var app = builder.Build();

// 3. Configuração do ambiente e Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitando a política de CORS definida acima
app.UseCors("AllowAll");

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            Erro = "Ocorreu uma falha interna no servidor.",
            Dica = "Verifique a comunicação com o banco de dados Oracle e se as tabelas existem."
        });
    });
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();