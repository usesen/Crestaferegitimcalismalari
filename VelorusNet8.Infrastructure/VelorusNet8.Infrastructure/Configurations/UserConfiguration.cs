using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
          // Tablo ismi
            builder.ToTable("UserAccounts");

            // Birincil anahtar
            builder.HasKey(ua => ua.UserId);

            // Kullanıcı ismi zorunlu ve maksimum uzunluk 100 karakter
            builder.Property(ua => ua.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Email zorunlu ve maksimum uzunluk 100 karakter
            builder.Property(ua => ua.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            // PasswordHash zorunlu ve maksimum uzunluk 255 karakter
            builder.Property(ua => ua.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(255);

            // Aktif/Pasif durumu zorunlu
            builder.Property(ua => ua.IsActive)
                   .IsRequired();

            // UserAccount ile UserAccountGroup arasındaki ilişki
            builder.HasMany(ua => ua.UserAccountGroups)
                   .WithOne(uag => uag.UserAccount)
                   .HasForeignKey(uag => uag.UserAccountId)
                   .OnDelete(DeleteBehavior.Cascade);

            // UserAccount ile MenuPermission arasındaki ilişki
            builder.HasMany(ua => ua.MenuPermissions)
                   .WithOne(mp => mp.UserAccount)
                   .HasForeignKey(mp => mp.UserAccountId)
                   .OnDelete(DeleteBehavior.Cascade);

        
        // UserAccount ile UserBranch arasındaki ilişki (birden fazla şubeye sahip olabilir)
        builder.HasMany(ua => ua.UserBranches)
            .WithOne(ub => ub.UserAccount)
            .HasForeignKey(ub => ub.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade Delete yerine Restrict kullanıyoruz

    }
}