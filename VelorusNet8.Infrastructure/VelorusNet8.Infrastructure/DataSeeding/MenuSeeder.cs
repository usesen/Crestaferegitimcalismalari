using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Infrastructure.DataSeeding;

public static class MenuSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>().HasData(
            new Menu
            {
                MenuId = 1,
                Title = "Dashboard",
                Icon = "home",
                Url = "/dashboard",
                ParentMenuId = null
            },
            new Menu
            {
                MenuId = 2,
                Title = "Settings",
                Icon = "settings",
                Url = "/settings",
                ParentMenuId = null
            }
        );
    }
}

