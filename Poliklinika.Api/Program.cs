using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Poliklinika.Application.Interfaces;
using Poliklinika.Application.Services;
using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;
using Poliklinika.Infrastructure.Repositories;
using Poliklinka.Domain.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepository<PatientEntity>,Repository<PatientEntity>>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IRepository<DoctorEntity>, Repository<DoctorEntity>>();
builder.Services.AddTransient<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddTransient<AppontmentService>();
builder.Services.AddMemoryCache();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();



app.UseAuthorization();

app.MapControllers();

app.Run();
