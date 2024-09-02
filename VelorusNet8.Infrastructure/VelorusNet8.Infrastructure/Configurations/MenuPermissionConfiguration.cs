using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Infrastructure.Configurations;

public class MenuPermissionConfiguration : IEntityTypeConfiguration<MenuPermission>
{
    public void Configure(EntityTypeBuilder<MenuPermission> builder)
    {
        // Tablo ismi
        builder.ToTable("MenuPermissions");

        // Birincil anahtar
        builder.HasKey(mp => mp.MenuPermissionId);

        // Menu ile ilişki (Zorunlu)
        builder.HasOne(mp => mp.Menu)
               .WithMany(m => m.MenuPermissions)
               .HasForeignKey(mp => mp.MenuId)
               .OnDelete(DeleteBehavior.Cascade);

        // UserAccount ile ilişki (Opsiyonel)
        builder.HasOne(mp => mp.UserAccount)
               .WithMany(ua => ua.MenuPermissions)
               .HasForeignKey(mp => mp.UserAccountId)
               .OnDelete(DeleteBehavior.Cascade);

        // Group ile ilişki (Opsiyonel)
        builder.HasOne(mp => mp.UserGroup)
               .WithMany(g => g.MenuPermissions)
               .HasForeignKey(mp => mp.GroupId)
               .OnDelete(DeleteBehavior.Cascade);

        // Görüntüleme, düzenleme, silme ve raporlama izinleri
        builder.Property(mp => mp.CanView)
               .IsRequired();

        builder.Property(mp => mp.CanEdit)
               .IsRequired();

        builder.Property(mp => mp.CanDelete)
               .IsRequired();

        builder.Property(mp => mp.CanExcel)
               .IsRequired();

        builder.Property(mp => mp.CanPdf)
               .IsRequired();

        builder.Property(mp => mp.CanWord)
               .IsRequired();
    }
}
