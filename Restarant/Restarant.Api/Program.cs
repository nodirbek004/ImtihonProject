using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restarant.Application.Interfaces;
using Restarant.Application.Services;
using Restarant.Domain.Entities;
using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;
using Restarant.Infrastructure.Repositoies;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "Issuer",
            ValidateAudience = true,
            ValidAudience = "Audience",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mana-shu-security-key"))
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IRepository<Admin>, Repositories<Admin>>();
builder.Services.AddTransient<ICookService, CookService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IWaiterService, WaiterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
