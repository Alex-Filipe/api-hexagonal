using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Adapters.ORM.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Adapters.ORM.EFCore.ModelConfiguration;

public class SectorModelConfiguration : IEntityTypeConfiguration<SectorModel>
{
    public void Configure(EntityTypeBuilder<SectorModel> builder)
    {
        builder.ToTable("Sectors", EFContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}