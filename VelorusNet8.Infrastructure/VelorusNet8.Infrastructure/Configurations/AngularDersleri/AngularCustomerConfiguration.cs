using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

namespace VelorusNet8.Infrastructure.Configurations.AngularDersleri;

public class AngularCustomerConfiguration : IEntityTypeConfiguration<AngularCustomer>
{
    public void Configure(EntityTypeBuilder<AngularCustomer> builder)
    {
        // Tablonun adı
        builder.ToTable("AngularCustomers");

        // Primary Key
        builder.HasKey(ac => ac.id);

        // Properties mapping
        builder.Property(ac => ac.firstName)
            .HasMaxLength(100)
            .IsRequired();  // Zorunlu alan (NOT NULL)

        builder.Property(ac => ac.lastName)
            .HasMaxLength(100)
            .IsRequired();  // Zorunlu alan (NOT NULL)

        builder.Property(ac => ac.email)
            .HasMaxLength(200)
            .IsRequired();  // Zorunlu alan (NOT NULL)

        builder.Property(ac => ac.phone)
            .HasMaxLength(20);

        builder.Property(ac => ac.address)
            .HasMaxLength(500);

        builder.Property(ac => ac.city)
            .HasMaxLength(100);

        builder.Property(ac => ac.country)
            .HasMaxLength(100);

        builder.Property(ac => ac.postalCode)
            .HasMaxLength(10);

        builder.Property(ac => ac.company)
            .HasMaxLength(200);

        builder.Property(ac => ac.position)
            .HasMaxLength(100);

        builder.Property(ac => ac.notes)
            .HasMaxLength(500);

        // Eğer başka ilişkiler ve indexler tanımlamak isterseniz, bunları da buraya ekleyebilirsiniz.
    }

  
}
