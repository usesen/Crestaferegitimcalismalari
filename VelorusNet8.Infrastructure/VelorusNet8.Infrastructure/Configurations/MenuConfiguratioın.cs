using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Infrastructure.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menu");
        // Menu - Self Reference
        // Tablo ismi
        builder.ToTable("Menus");

        // Birincil anahtar
        builder.HasKey(m => m.MenuId);

        // Title zorunlu ve maksimum uzunluk 100 karakter
        builder.Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(100);

        // Icon isteğe bağlı, maksimum uzunluk 50 karakter
        builder.Property(m => m.Icon)
               .HasMaxLength(50);

        // URL isteğe bağlı, maksimum uzunluk 200 karakter
        builder.Property(m => m.Url)
               .HasMaxLength(200);

        // ParentMenu ile Self-referencing ilişki
        builder.HasOne(m => m.ParentMenu)
               .WithMany(m => m.SubMenus)
               .HasForeignKey(m => m.ParentMenuId)
               .OnDelete(DeleteBehavior.Restrict);

        // Menu ile MenuPermission arasındaki ilişki
        builder.HasMany(m => m.MenuPermissions)
               .WithOne(mp => mp.Menu)
               .HasForeignKey(mp => mp.MenuId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
