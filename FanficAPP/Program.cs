using System.Text;
using FanficAPP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Conectando com o banco de dados.
builder.Services.AddDbContext<FanficAPPDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

// Autenticação JWT

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

// Começo MAIN Config JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "ThePixeler", // Lembrar de Trocar o Nome
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });
    
// Fim MAIN Config JWT

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(); // Config JWT
builder.Services.AddAuthorization(); // Config JWT

var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

app.UseAuthentication(); // Config JWT
app.UseAuthorization(); // Config JWT


// Rodando!
app.Run();

