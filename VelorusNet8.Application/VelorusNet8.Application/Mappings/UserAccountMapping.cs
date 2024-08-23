
using AutoMapper;
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

        // UserDto -> UserAccount Mapping
        CreateMap<UserAccountDto, UserAccount>()
            .ConstructUsing(dto => new UserAccount(0, dto.UserName, dto.Email, string.Empty)) // PasswordHash varsayılan olarak boş veriliyor
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // PasswordHash'i DTO'dan map etmiyoruz
    }
}