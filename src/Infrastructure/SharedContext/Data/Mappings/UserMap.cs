using Core.UserContext.Entities;
using Core.VaccineCardContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.SharedContext.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        
        builder
            .HasKey(x => x.Id)
            .HasName("PK_User");
        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasColumnName("PasswordHash")
            .HasMaxLength(50);
       
        builder.OwnsOne(x => x.Name, name =>
        {
            name.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasColumnName("FirstName")
                .HasMaxLength(50);
            name.Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasColumnName("LastName")
                .HasMaxLength(50);
        });
        builder.OwnsOne(x => x.Email, email =>
        {
            email.WithOwner();
            email.HasIndex(x => x.Address)
                .HasDatabaseName("IX_User_Email")
                .IsUnique();
            email.Property(x => x.Address)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasColumnName("Email")
                .HasMaxLength(200);
            email.Property(e => e.Hash)
                .HasMaxLength(200)
                .HasColumnName("EmailHash");
            
        });
        builder.OwnsOne(x => x.Cpf, cpf =>
        {
            cpf.Property(x => x.NumberCpf)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasColumnName("Cpf")
                .HasMaxLength(11);
        });

        builder.OwnsOne(x => x.Age, age =>
        {
            age.Property(x => x.Number)
                .IsRequired()
                .HasColumnType("INT")
                .HasColumnName("Age")
                .HasMaxLength(3);
        });

        builder.OwnsOne(x => x.Gender, gender =>
        {
            gender.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasColumnName("Gender")
                .HasMaxLength(15);
            

        });
        builder.OwnsOne(x => x.SusNumber, sus =>
        {
            sus.Property(x => x.NumberSus)
                .HasColumnType("NVARCHAR")
                .HasColumnName("SusNumber")
                .HasMaxLength(15);
        });

        builder.OwnsOne(x => x.Allergy, allergy =>
        {
            allergy.Property(x => x.Value)
                .HasColumnType("bit")
                .HasColumnName("Allergy");
            allergy.Property(x => x.Description)
                .HasColumnType("NVARCHAR")
                .HasColumnName("Description")
                .HasMaxLength(200);
        });
        builder.OwnsOne(x => x.Allergy, allergy =>
        {
            allergy.Property(x => x.Value)
                .HasColumnType("bit")
                .HasColumnName("Allergy");
            allergy.Property(x => x.Description)
                .HasColumnType("NVARCHAR")
                .HasColumnName("Description")
                .HasMaxLength(200);
        });
    
        builder.HasOne(x => x.Card)
            .WithOne(x => x.user)
            .HasForeignKey<VaccineCard>(x => x.UserId);

        
    }
}