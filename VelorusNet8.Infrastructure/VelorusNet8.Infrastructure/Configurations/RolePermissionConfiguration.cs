using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Infrastructure.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");
        builder.HasKey(rp => rp.Id);

        // Role ile ilişki
        builder.HasOne(rp => rp.Role)
               .WithMany(r => r.RolePermissions)
               .HasForeignKey(rp => rp.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

        // Permission ile ilişki
        builder.HasOne(rp => rp.Permission)
               .WithMany(p => p.RolePermissions)
               .HasForeignKey(rp => rp.PermissionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}