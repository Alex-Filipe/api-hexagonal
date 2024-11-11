using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Adapters.ORM.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Adapters.ORM.EFCore.ModelConfiguration;

public class PersonModelConfiguration : IEntityTypeConfiguration<PersonModel>
{
    public void Configure(EntityTypeBuilder<PersonModel> builder)
    {
        builder
            .ToTable("Persons", EFContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(model => model.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(model => model.PasswordHash)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(model => model.Cpf)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(model => model.Age)
            .IsRequired();

        // Relacionamentos

        builder.HasOne(model => model.Profile)
            .WithMany()
            .HasForeignKey(p => p.Id)
            .IsRequired();

        builder.HasOne(model => model.Region)
            .WithMany()
            .HasForeignKey(model => model.Id)
            .IsRequired();

        builder.HasOne(model => model.City)
            .WithMany()
            .HasForeignKey(model => model.Id)
            .IsRequired();

        builder.HasOne(model => model.Sector)
            .WithMany()
            .HasForeignKey(model => model.Id)
            .IsRequired();

        builder.HasOne(model => model.Cooperative)
            .WithMany()
            .HasForeignKey(model => model.Id)
            .IsRequired();
    }
}