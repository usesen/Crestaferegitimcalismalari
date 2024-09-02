using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Infrastructure.Configurations;

public class UserAccountGroupConfiguration : IEntityTypeConfiguration<UserAccountGroup>
{
    public void Configure(EntityTypeBuilder<UserAccountGroup> builder)
    {
        // Tablo ismi
        builder.ToTable("UserAccountGroups");

        // Birincil anahtar olarak birleşik bir anahtar kullanıyoruz
        builder.HasKey(uag => new { uag.UserAccountId, uag.GroupId });

        // UserAccount ile ilişki
        builder.HasOne(uag => uag.UserAccount)
               .WithMany(ua => ua.UserAccountGroups)
               .HasForeignKey(uag => uag.UserAccountId)
               .OnDelete(DeleteBehavior.Cascade);

        // UserGroup ile ilişki
        builder.HasOne(uag => uag.UserGroup)
               .WithMany(ug => ug.UserAccountGroups)
               .HasForeignKey(uag => uag.GroupId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}