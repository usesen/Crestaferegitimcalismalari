using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VelorusNet8.Application.Behaviors;
using VelorusNet8.Application.Commands.Group;
using VelorusNet8.Application.Commands.Group.Validator;
using VelorusNet8.Application.Commands.Menu;
using VelorusNet8.Application.Commands.Menu.Validator;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Application.Interface.User;
using VelorusNet8.Application.Service;


namespace VelorusNet8.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       
        // AutoMapper'ı konfigüre et
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // FluentValidation'ı konfigüre et
        services.AddValidatorsFromAssemblyContaining<UserAccountCommandValidator>();
        // MediatR'ı konfigüre et
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        // ValidationBehavior'ı konfigüre et
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Servisleri DI konteynerine ekle



        services.AddScoped<IUserGroupService, UserGroupService>();
        // Command Validator'lar
        services.AddScoped<IValidator<CreateUserAccountGroupCommand>, CreateUserAccountGroupCommandValidator>();
        services.AddScoped<IValidator<UpdateUserAccountGroupCommand>, UpdateUserAccountGroupCommandValidator>();
        services.AddScoped<IValidator<DeleteUserAccountGroupCommand>, DeleteUserAccountGroupCommandValidator>();

        // Command Handler'lar
        services.AddScoped<IRequestHandler<CreateUserAccountGroupCommand, int>, CreateUserAccountGroupCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserAccountGroupCommand, Unit>, UpdateUserAccountGroupCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteUserAccountGroupCommand, Unit>, DeleteUserAccountGroupCommandHandler>();

        services.AddScoped<IUserAccountService, UserAccountService>();
        services.AddScoped<IUserAccountGroupService, UserAccountGroupService>();
        services.AddScoped<IRequestHandler<DeleteUserAccountGroupCommand, Unit>, DeleteUserAccountGroupCommandHandler>();
        services.AddScoped<IValidator<CreateUserAccountGroupCommand>, CreateUserAccountGroupCommandValidator>();
        services.AddScoped<IValidator<DeleteUserAccountGroupCommand>, DeleteUserAccountGroupCommandValidator>();
        services.AddScoped<IValidator<DeleteUserAccountGroupCommand>, DeleteUserAccountGroupCommandValidator>();
        

        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IValidator<CreateMenuCommand>, CreateMenuCommandValidator>();
        services.AddScoped<IValidator<UpdateMenuCommand>, UpdateMenuCommandValidator>();
        services.AddScoped<IValidator<DeleteMenuCommand>, DeleteMenuCommandValidator>();


        services.AddScoped<IMenuPermissionService, MenuPermissionService>();
        services.AddScoped<IValidator<CreateMenuPermissionCommand>, CreateMenuPermissionCommandValidator>();
        services.AddScoped<IValidator<UpdateMenuPermissionCommand>, UpdateMenuPermissionCommandValidator>();
        services.AddScoped<IValidator<DeleteMenuPermissionCommand>, DeleteMenuPermissionCommandValidator>();

        services.AddScoped<IRequestHandler<CreateMenuPermissionCommand, Unit>, CreateMenuPermissionCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateMenuPermissionCommand, Unit>, UpdateMenuPermissionCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteMenuPermissionCommand, Unit>, DeleteMenuPermissionCommandHandler>();






        // services.AddScoped<IOtherService, OtherService>();


        return services;
    }
}