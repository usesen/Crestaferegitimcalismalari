﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Application.Dto.Identity.Permission.PermissionDTO;
using VelorusNet8.Application.Dto.User;

namespace VelorusNet8.Application.Dto.Identity.Role;

public class RoleDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<PermissionDTO> Permissions { get; set; }
    public List<UserAccountDto> Users { get; set; }
}
