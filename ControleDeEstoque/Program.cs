using Microsoft.EntityFrameworkCore;
using ControleDeEstoque.Db;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Controle de Estoque API",
        Version = "v1",
        Description = "API para controle de estoque de produtos"
    });
});

// Configurar DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ControleDeEstoque.Service.ProdutoService>();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();

// Swagger só em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Estoque API v1");
        c.RoutePrefix = string.Empty; // abre Swagger na raiz
    });
}

// Mapear controllers
app.MapControllers();

app.Run();