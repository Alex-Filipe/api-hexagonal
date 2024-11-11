using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Adapters.ORM.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Adapters.ORM.EFCore.ModelConfiguration;

public class ProfileModelConfiguration : IEntityTypeConfiguration<ProfileModel>
{
    public void Configure(EntityTypeBuilder<ProfileModel> builder)
    {
        builder
            .ToTable("Profiles", EFContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}