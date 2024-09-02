using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Infrastructure.DataSeeding;

public static class UserAccountGroupSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAccountGroup>().HasData(
            new UserAccountGroup
            {
                UserAccountId = 1,
                GroupId = 1  // Admin kullanıcısı, Administrators grubuna ait
            },
            new UserAccountGroup
            {
                UserAccountId = 2,
                GroupId = 2  // Normal kullanıcı, Users grubuna ait
            }
        );
    }
}

