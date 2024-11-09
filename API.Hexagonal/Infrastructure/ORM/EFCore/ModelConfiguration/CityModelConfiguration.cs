using API.Hexagonal.Infrastructure.ORM.EFCore.Context;
using API.Hexagonal.Infrastructure.ORM.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Infrastructure.ORM.EFCore.ModelConfiguration;

public class CityModelConfiguration : IEntityTypeConfiguration<CityModel>
{
    public void Configure(EntityTypeBuilder<CityModel> builder)
    {
        builder
            .ToTable("Cities", EFContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}