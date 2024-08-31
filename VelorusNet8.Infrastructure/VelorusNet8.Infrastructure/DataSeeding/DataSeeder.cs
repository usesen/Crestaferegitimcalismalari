using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Users;


namespace VelorusNet8.Infrastructure.DataSeeding;

public static  class DataSeeder
{
 
    public static  void SeedData(this ModelBuilder modelBuilder)
    {   //Branch data
        modelBuilder.Entity<CompanyBranch>().HasData(
            new CompanyBranch
            {
                Id = 1,
                BranchCode = "S001",
                BranchName = "Ana Şube (Patron)",
                Address = "Merkez",
                Phone = "555-1234",
                Fax = "555-5678",
                Email = "info@Velorus.com",
                CommissionRate = 0.00m,
                CommissionAmount = 0m,
                DefaultShrinkageRate = 0.0m,
                IsHeadOffice = true,
                IsSalesEnabled = true,
                IsAutomationIntegrationEnabled = true
            }
        );

        // UserAccount Data
        modelBuilder.Entity<UserAccount>().HasData(
         new UserAccount
         {
             UserId = 1,
             UserName = "admin",
             Email = "admin@example.com",
             PasswordHash = "hashed_password",
             IsActive = true,
             CreatedBy = "system",            // Zorunlu alan
             CreatedDate = DateTime.Now,   // Zorunlu alan
             LastModifiedBy = "system",       // Zorunlu alan
             LastModifiedDate = DateTime.Now // Zorunlu alan (eğer varsa)
         });
         modelBuilder.Entity<UserBranch>().HasData(
            new UserBranch(1, 1));
    }
}