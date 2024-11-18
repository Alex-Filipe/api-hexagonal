using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Adapters.ORM.EFCore.Mappings;
using API.Hexagonal.Adapters.ORM.EFCore.Repositories;
using API.Hexagonal.Adapters.Security;
using API.Hexagonal.Application.Interfaces;
using API.Hexagonal.Application.Mappers;
using API.Hexagonal.Application.Services;
using API.Hexagonal.Domain.Repositories;
using API.Hexagonal.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Repositories
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IEntityRepository, EntityRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();


// Services
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

// Mappers
builder.Services.AddAutoMapper(typeof(CityProfile));
builder.Services.AddAutoMapper(typeof(CooperativeProfile));
builder.Services.AddAutoMapper(typeof(EnterpriseProfile));
builder.Services.AddAutoMapper(typeof(PersonProfile));
builder.Services.AddAutoMapper(typeof(PersonAppProfile));
builder.Services.AddAutoMapper(typeof(ProfileProfile));
builder.Services.AddAutoMapper(typeof(RegionProfile));
builder.Services.AddAutoMapper(typeof(SectorProfile));

// Database
var databaseProvider = builder.Configuration["DatabaseProvider"];

switch (databaseProvider)
{
    case "MySQL":
        builder.Services.AddDbContext<EFContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("MySQLConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
            {
                mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
            });
        });
        break;

    // case "PostgreSQL":
    //     builder.Services.AddDbContext<EFContext>((serviceProvider, options) =>
    //     {
    //         var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    //         var connectionString = configuration.GetConnectionString("PostgreSQLConnection");
    //         options.UseNpgsql(connectionString);
    //     });
    //     break;

    default:
        throw new Exception("Provedor de banco de dados não suportado.");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();

app.Run();