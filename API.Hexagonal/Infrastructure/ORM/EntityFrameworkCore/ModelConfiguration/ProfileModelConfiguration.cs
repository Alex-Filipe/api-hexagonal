using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Context;
using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.ModelConfiguration;

public class ProfileModelConfiguration : IEntityTypeConfiguration<ProfileModel>
{
    public void Configure(EntityTypeBuilder<ProfileModel> builder)
    {
        builder
            .ToTable("Profiles", EntityFrameworkContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}