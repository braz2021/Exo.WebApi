using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura o contexto para usar MySQL
builder.Services.AddDbContext<ExoContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23))));

builder.Services.AddTransient<ProjetoRepository>();

builder.Services.AddControllers();
builder.Services.AddTransient<UsuarioRepository,UsuarioRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
