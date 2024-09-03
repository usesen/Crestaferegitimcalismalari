using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelorusNet8.Application.DTOs.Group;

public class UserGroupPermissionDto
{
    public int PermissionId { get; set; }  // İznin benzersiz kimliği

    public string PermissionName { get; set; }  // İznin adı

    public string Description { get; set; }  // İznin açıklaması

    public bool IsGranted { get; set; }  // İznin verilip verilmediği

    public UserGroupPermissionDto(int permissionId, string permissionName, string description, bool ısGranted)
    {
        PermissionId = permissionId;
        PermissionName = permissionName;
        Description = description;
        IsGranted = ısGranted;
      
    }
}