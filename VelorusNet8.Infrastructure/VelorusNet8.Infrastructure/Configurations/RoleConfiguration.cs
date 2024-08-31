using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).IsRequired().HasMaxLength(100);

        // Role ile RolePermission arasındaki ilişki
        builder.HasMany(r => r.RolePermissions)
               .WithOne(rp => rp.Role)
               .HasForeignKey(rp => rp.RoleId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}