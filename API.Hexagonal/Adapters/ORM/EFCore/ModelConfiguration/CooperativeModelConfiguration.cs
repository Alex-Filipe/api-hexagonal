using API.Hexagonal.Adapters.ORM.EFCore.Context;
using API.Hexagonal.Adapters.ORM.EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Adapters.ORM.EFCore.ModelConfiguration;

public class CooperativeModelConfiguration : IEntityTypeConfiguration<CooperativeModel>
{
    public void Configure(EntityTypeBuilder<CooperativeModel> builder)
    {
        builder
            .ToTable("Cooperatives", EFContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasOne(model => model.Enterprise)
            .WithMany()
            .HasForeignKey(model => model.EnterpriseId)
            .IsRequired();
    }
}