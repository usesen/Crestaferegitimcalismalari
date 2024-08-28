using AutoMapper;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.WepApi.WpDto.WpUser;

namespace VelorusNet8.WebApi.Mapping;

public class UserAccountMapping : Profile
{
    public UserAccountMapping()
    {
        // CreateUserAcountDtoWpa'dan CreateUserAccountDto'ya mapleme
        CreateMap<CreateUserAcountDtoWpa, CreateUserAccountDto>();

        // İki yönlü dönüşüm gerekiyorsa (opsiyonel)
        CreateMap<CreateUserAccountDto, CreateUserAcountDtoWpa>();

    }
}