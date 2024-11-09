using API.Hexagonal.Infrastructure.ORM.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();

// Configure o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
