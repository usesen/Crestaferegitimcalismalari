using VelorusNet8.Application.Dto.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using AutoMapper;

namespace VelorusNet8.Application.Mappings;

public class BranchMapping : Profile
{
    public BranchMapping()
    {
        // Entity'den DTO'ya dönüşüm
        CreateMap<BranchEntity, BranchDto>();

        // DTO'dan Entity'ye dönüşüm
        CreateMap<CreateBranchDto, BranchEntity>();
        CreateMap<UpdateBranchDto, BranchEntity>()
            .ForMember(dest => dest.BranchCode, opt => opt.Ignore()); // Genellikle güncellemelerde ID/BranchCode değiştirilmez
    }
}