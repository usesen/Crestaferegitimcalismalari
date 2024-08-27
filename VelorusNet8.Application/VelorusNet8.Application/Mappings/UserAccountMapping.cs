
using AutoMapper;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Application.Mappings;

public class UserAccountMapping : Profile
{
    public UserAccountMapping()
    {
        // UserAccount -> UserDto Mapping
        CreateMap<UserAccount, UserAccountDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<CreateUserAccountCommand, UserAccount>();

        CreateMap<CreateUserAccountDto, UserAccountDto>();
        // Eğer iki yönlü dönüşüm istiyorsanız:
        CreateMap<UserAccountDto, CreateUserAccountDto>();
    }
}