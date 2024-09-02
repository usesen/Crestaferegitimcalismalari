using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Infrastructure.DataSeeding;

public static class UserGroupSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserGroup>().HasData(
            new UserGroup
            {
                Id = 1,
                Name = "Administrators"
            },
            new UserGroup
            {
                Id = 2,
                Name = "Users"
            }
        );
    }
}