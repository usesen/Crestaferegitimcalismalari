// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using UserSubeEntegrasyonTest;

Console.WriteLine("Hello, World!");
using (var context = new AppDbContext())
{

    int userId = 2;
    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            // Mevcut şubeleri sil ve yeni şubeleri ekle (örnek 1 ya da 2'deki gibi)
            var userQuery = context.UserAccounts.Include(u => u.UserBranches)
                                   .FirstOrDefault(u => u.ID == userId);

            if (userQuery != null)
            {
                // Mevcut şubeleri sil
                context.UserBranches.RemoveRange(userQuery.UserBranches);

                context.SaveChanges();
            }

            context.SaveChanges();
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    // Şube ekleyelim
    var branch = new Branch(branchName: "Branch 1");
    context.Branches.Add(branch);
    context.SaveChanges();

    // Kullanıcı ekleyelim
    var user = new UserAccount("user1", "user1@example.com", "hashedpassword");

    context.UserAccounts.Add(user);
    context.SaveChanges();

    // Kullanıcıyı şubelere yetkilendirelim
    var userBranch1 = new UserBranch(user.ID, branch.BranchId);
    

    userBranch1.SetUserAccount(user);
    userBranch1.SetBranch(branch);
    context.UserBranches.Add(userBranch1);

    context.SaveChanges();

    // Kullanıcının şubelerini listeleyelim
    var userWithBranches = context.UserAccounts
        .Include(u => u.UserBranches)
        .ThenInclude(ub => ub.Branch)
        .FirstOrDefault(u => u.ID == 1);

    if (userWithBranches != null)
    {
        Console.WriteLine($"User {userWithBranches.UserName} is assigned to the following branches:");
        foreach (var ub in userWithBranches.UserBranches)
        {
            Console.WriteLine($" - {ub.Branch.BranchName}");
        }
    }
}