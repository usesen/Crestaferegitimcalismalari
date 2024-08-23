using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<UserBranch> UserBranches { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Composite key tanımlıyoruz
        modelBuilder.Entity<UserBranch>()
            .HasKey(ub => new { ub.UserId, ub.BranchId });

        // UserAccount ile UserBranch ilişkisini tanımlıyoruz
        modelBuilder.Entity<UserBranch>()
            .HasOne(ub => ub.UserAccount)
            .WithMany(u => u.UserBranches)
            .HasForeignKey(ub => ub.UserId);

        // Branch ile UserBranch ilişkisini tanımlıyoruz
        modelBuilder.Entity<UserBranch>()
            .HasOne(ub => ub.Branch)
            .WithMany()
            .HasForeignKey(ub => ub.BranchId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // MSSQL veritabanı bağlantı dizesini burada belirtiyoruz.
        optionsBuilder.UseSqlServer("Server=DESKTOP-6QR83E3\\UGURMSSQL;Database=AppUsers;User Id=usesen;Password=usesen;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True;TrustServerCertificate=True;");
    }

}
