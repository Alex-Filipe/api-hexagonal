using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Context;
using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.ModelConfiguration;

public class SectorModelConfiguration : IEntityTypeConfiguration<SectorModel>
{
    public void Configure(EntityTypeBuilder<SectorModel> builder)
    {
        builder.ToTable("Sectors", EntityFrameworkContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}