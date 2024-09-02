using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Infrastructure.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
      public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        // Tablo ismi
        builder.ToTable("UserGroups");

        // Birincil anahtar
        builder.HasKey(g => g.Id);

        // GroupName zorunlu ve maksimum uzunluk 100 karakter
        builder.Property(g => g.Name)
               .IsRequired()
               .HasMaxLength(100);

        // UserAccountGroup ile ilişki
        builder.HasMany(g => g.UserAccountGroups)
               .WithOne(uag => uag.UserGroup)
               .HasForeignKey(uag => uag.GroupId)
               .OnDelete(DeleteBehavior.Cascade);

        // MenuPermission ile ilişki
        builder.HasMany(g => g.MenuPermissions)
               .WithOne(mp => mp.UserGroup)
               .HasForeignKey(mp => mp.GroupId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}