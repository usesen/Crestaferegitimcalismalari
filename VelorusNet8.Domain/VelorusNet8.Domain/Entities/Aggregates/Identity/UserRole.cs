using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Domain.Entities.Aggregates.Identity;


public class UserRole
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public UserAccount User { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}