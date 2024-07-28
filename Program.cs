using Exo.WebApi.Contexts;
using Exo.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configura o contexto para usar MySQL
builder.Services.AddDbContext<ExoContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 23))));

// Adiciona o contexto como serviço
builder.Services.AddScoped<ExoContext>();

// Adiciona os controladores e os serviços necessários
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de autenticação
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
// Parâmetros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Valida quem está solicitando
        ValidateAudience = true, // Valida quem está recebendo
        ValidateLifetime = true, // Define se o tempo de expiração será validado
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("exoapichave-autenticacao")), // Criptografia e validação da chave de autenticação
        ClockSkew = TimeSpan.FromMinutes(30), // Valida o tempo de expiração do token
        ValidIssuer = "exoapi.webapi", // Nome do issuer, da origem
        ValidAudience = "exoapi.webapi" // Nome do audience, para o destino
    };
});

builder.Services.AddTransient<ProjetoRepository>();
builder.Services.AddTransient<UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Habilita a autenticação
app.UseAuthentication();
// Habilita a autorização
app.UseAuthorization();

app.MapControllers();

app.Run();
