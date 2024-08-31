using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
        builder.HasKey(ur => ur.Id);

        // User ile ilişki
        builder.HasOne(ur => ur.User)
               .WithMany(u => u.UserRoles)
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Role ile ilişki
        builder.HasOne(ur => ur.Role)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(ur => ur.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}