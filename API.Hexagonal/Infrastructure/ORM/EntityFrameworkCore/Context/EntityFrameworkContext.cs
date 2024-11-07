using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Context;

public class EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options) : DbContext(options)
{
    public const string Schema = "tester";
    
    public DbSet<CityModel> Cities { get; set; }
    public DbSet<CooperativeModel> Cooperatives { get; set; }
    public DbSet<EnterpriseModel> Enterprises { get; set; }
    public DbSet<PersonModel> Persons { get; set; }
    public DbSet<ProfileModel> Profiles { get; set; }
    public DbSet<RegionModel> Regions { get; set; }
    public DbSet<SectorModel> Sectors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityFrameworkContext).Assembly);
    }
}