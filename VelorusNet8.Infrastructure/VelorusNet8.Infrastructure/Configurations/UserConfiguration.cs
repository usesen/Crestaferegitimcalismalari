using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);

        // User ile UserRole arasındaki ilişki
        builder.HasMany(u => u.UserRoles)
               .WithOne(ur => ur.User)
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}