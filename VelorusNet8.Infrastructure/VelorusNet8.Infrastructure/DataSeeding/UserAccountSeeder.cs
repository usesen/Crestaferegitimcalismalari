using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Infrastructure.DataSeeding;

public static  class UserAccountSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {   //Branch data
        modelBuilder.Entity<UserAccount>().HasData(
            new UserAccount
            {
                UserId = 1,
                UserName = "admin",
                Email = "admin@example.com",
                PasswordHash = "hashedpassword",  // Gerçek bir şifreleme kullanmalısınız
                IsActive = true
            },
                  new UserAccount
                  {
                      UserId = 2,
                      UserName = "user",
                      Email = "user@example.com",
                      PasswordHash = "hashedpassword",
                      IsActive = true
                  }
        );


       
    }
}
