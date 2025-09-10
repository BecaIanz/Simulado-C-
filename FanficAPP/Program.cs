using System.Text;
using FanficAPP.Models;
using FanficAPP.Services.JWT;
using FanficAPP.Services.Profile;
using FanficAPP.UseCases.CreateFanfic;
using FanficAPP.UseCases.DeleteFanfic;
using FanficAPP.UseCases.EditList;
using FanficAPP.UseCases.GetList;
using FanficAPP.UseCases.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ThePixeler.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FanficAPPDbContext>(options =>
    options.UseInMemoryDatabase("MeuBancoInMemory"));


// Configurar Serviços
builder.Services.AddTransient<IJWTService, JWTService>();
builder.Services.AddTransient<IProfileService, EFProfileService>();

//Configurar UseCases
builder.Services.AddTransient<CreateFanficUseCase>();
builder.Services.AddTransient<DeleteFanficUseCase>();
builder.Services.AddTransient<EditListUseCase>();
builder.Services.AddTransient<GetListUseCase>();
builder.Services.AddTransient<LoginUseCase>();

// Autenticação JWT

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

// Começo MAIN Config JWT
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new()
//         {
//             ValidateIssuer = false,
//             ValidateAudience = false,
//             ValidIssuer = "FanficAPP", // Lembrar de Trocar o Nome
//             ValidateIssuerSigningKey = true,
//             ValidateLifetime = true,
//             ClockSkew = TimeSpan.Zero,
//             IssuerSigningKey = key,
//         };
//     });
    
builder.Services.AddAuthentication(); // Config JWT
builder.Services.AddAuthorization(); // Config JWT


var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

app.UseAuthentication(); // Config JWT
app.UseAuthorization(); // Config JWT


// Rodando!
app.Run();