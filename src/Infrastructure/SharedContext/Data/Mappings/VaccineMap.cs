using Core.VaccineContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.SharedContext.Data.Mappings;

public class VaccineMap : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.ToTable("Vaccine");
        
        builder
            .HasKey(x => x.Id)
            .HasName("PK_Vaccine");
        
        
        builder.OwnsOne(x => x.VacciName, name =>
        {
            name.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasColumnName("Name")
                .HasMaxLength(50);
        });

        builder.OwnsOne(x => x.Manufacturer, manufacturer =>
        {
            manufacturer.Property(x => x.Enterprise)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasColumnName("Manufacture")
                .HasMaxLength(100);
        });
        builder.Property(x => x.CategoryType)
            .IsRequired()
            .HasColumnName("CategoryType")
            .HasConversion<string>() 
            .HasMaxLength(20)
            .HasColumnType("NVARCHAR");
        builder.Property(x => x.DoseType)
            .IsRequired()
            .HasColumnName("DoseType")
            .HasConversion<int>() 
            .HasMaxLength(10)
            .HasColumnType("INT");
        builder.Property(x => x.Index)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Index");
        builder.Property(x => x.MinimumAgeInMonths)
            .HasColumnType("int")
            .HasColumnName("MinimumAgeInMonths")
            .HasMaxLength(20);
        builder.Property(x => x.IsMandatory)
            .IsRequired()
            .HasColumnType("bit")
            .HasColumnName("Mandatory")
            .HasDefaultValue(false);
    }
}