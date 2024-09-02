using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Infrastructure.DataSeeding;

public static class MenuPermissionSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuPermission>().HasData(
            new MenuPermission
            {
                MenuPermissionId = 1,
                MenuId = 1,
                UserAccountId = 1,  // Administrators
                CanView = true,
                CanEdit = true,
                CanDelete = true,
                CanExcel = true,
                CanPdf = true,
                CanWord = true
            },
            new MenuPermission
            {
                MenuPermissionId = 2,
                MenuId = 1,
                UserAccountId = 2,  // Users
                CanView = true,
                CanEdit = false,
                CanDelete = false,
                CanExcel = false,
                CanPdf = false,
                CanWord = false
            }
        );
    }
}

