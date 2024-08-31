﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Infrastructure.Configurations;
using VelorusNet8.Infrastructure.DataSeeding;
using VelorusNet8.Infrastructure.Models;

namespace VelorusNet8.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<UserBranch> UserBranches { get; set; }
    public DbSet<CompanyBranch> CompanyBranches { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
           : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       

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
            .HasOne(ub => ub.CompanyBranch)
            .WithMany(cb => cb.UserBranches)
            .HasForeignKey(ub => ub.BranchId);

        // Ayrı sınıfları kullanarak yapılandırmaları uygulama
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());

        // Seed verilerini ekliyoruz
        modelBuilder.SeedData();

      
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // MSSQL veritabanı bağlantı dizesini burada belirtiyoruz.
       // optionsBuilder.UseSqlServer("Server=DESKTOP-6QR83E3\\UGURMSSQL;Database=AppUsers;User Id=usesen;Password=usesen;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True;TrustServerCertificate=True;");
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
    
        var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        userName = userName ?? "TestUser"; // Eğer null ise, "TestUser" olarak ayarlayın

        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
                entry.Entity.CreatedBy = userName; // Mevcut kullanıcı adı
                //entry.Entity.LastModifiedDate = DateTime.UtcNow;
                //entry.Entity.LastModifiedBy = userName; // Mevcut kullanıcı adı
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = userName; // Mevcut kullanıcı adı
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    //Add-Migration InitialCreate
    //Update-Database
    //dos komut satırına gidip ilgili dizinde aşağıdaki komutları yazıyoruz
    //dotnet ef migrations add SeedDataMigration
    //dotnet ef database update
}
