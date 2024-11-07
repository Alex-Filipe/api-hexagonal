using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Context;
using API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Hexagonal.Infrastructure.ORM.EntityFrameworkCore.ModelConfiguration;

public class CooperativeModelConfiguration : IEntityTypeConfiguration<CooperativeModel>
{
    public void Configure(EntityTypeBuilder<CooperativeModel> builder)
    {
        builder
            .ToTable("Cooperatives", EntityFrameworkContext.Schema)
            .HasKey(model => model.Id);
        
        builder.Property(model => model.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasOne(model => model.Enterprise)
            .WithMany()
            .HasForeignKey(model => model.Id)
            .IsRequired();
    }
}