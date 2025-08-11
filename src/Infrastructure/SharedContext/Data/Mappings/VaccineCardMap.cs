using System.Text.Json;
using Core.VaccineCardContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.SharedContext.Data.Mappings;

public class VaccineCardMap : IEntityTypeConfiguration<VaccineCard>
{
    public void Configure(EntityTypeBuilder<VaccineCard> builder)
    {
        builder.ToTable("VaccineCard");
        
        builder
            .HasKey(x => x.Id)
            .HasName("PK_VaccineCard");
        builder.Property(x => x.UserName)
            .HasColumnType("NVARCHAR")
            .HasColumnName("name")
            .HasMaxLength(50);
        builder.Property(x => x.UserCpf)
            .HasColumnType("NVARCHAR")
            .HasColumnName("Cpf")
            .HasMaxLength(11);
        builder.Property(x => x.UserSusNumber)
            .HasColumnType("NVARCHAR")
            .HasColumnName("SusNumber")
            .HasMaxLength(15);
        builder
            .Property(e => e.VaccineName)
            .HasConversion(
                v => v == null ? "[]" : JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => string.IsNullOrEmpty(v) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
            )
            .Metadata
            .SetValueComparer(new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            ));
    }
    
}