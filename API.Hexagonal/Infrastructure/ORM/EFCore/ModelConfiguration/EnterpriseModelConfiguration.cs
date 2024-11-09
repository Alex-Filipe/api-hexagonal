using API.Hexagonal.Infrastructure.ORM.EFCore.Context;
using API.Hexagonal.Infrastructure.ORM.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Infrastructure.ORM.EFCore.ModelConfiguration;

public class EnterpriseModelConfiguration : IEntityTypeConfiguration<EnterpriseModel>
{
    public void Configure(EntityTypeBuilder<EnterpriseModel> builder)
    {
        builder
            .ToTable("Enterprise", EFContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}