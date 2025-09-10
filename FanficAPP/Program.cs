using System.Text;
using FanficAPP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FanficAPPDbContext>(options =>
    options.UseInMemoryDatabase("MeuBancoInMemory"));

