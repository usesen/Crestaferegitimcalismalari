using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Infrastructure.DataSeeding;

public static class DataSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {   //Branch data
        modelBuilder.Entity<CompanyBranches>().HasData(
            new CompanyBranches
            {
                Id = 1,
                BranchCode = "B001",
                BranchName = "Main Branch",
                Address = "123 Main St",
                Phone = "555-1234",
                Fax = "555-5678",
                Email = "mainbranch@example.com",
                CommissionRate = 0.05m,
                CommissionAmount = 1000m,
                DefaultShrinkageRate = 0.02m,
                IsHeadOffice = true,
                IsSalesEnabled = true,
                IsAutomationIntegrationEnabled = true
            }
        );

        // UserAccount Data
        modelBuilder.Entity<UserAccount>().HasData(new UserAccount(1, "admin", "admin@example.com", "hashedpassword", true));
    }
}