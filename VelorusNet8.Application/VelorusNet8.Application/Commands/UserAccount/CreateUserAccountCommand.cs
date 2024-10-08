﻿using MediatR;
using VelorusNet8.Application.Dto.User;

namespace VelorusNet8.Application.Commands.UserAccount;

public class CreateUserAccountCommand : IRequest<int>  // int burada command sonucunda dönecek değeri temsil eder, örneğin yeni kullanıcının ID'si
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive{ get; set; }

    public CreateUserAccountCommand( string userName, string email, string passwordHash, bool isActive)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = isActive;
    }
}
