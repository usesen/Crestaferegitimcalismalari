using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;



namespace VelorusNet8.Infrastructure.DataSeeding;

public static  class BrunchDataSeeder
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
 
    }
}