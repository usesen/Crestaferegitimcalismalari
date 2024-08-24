using AutoMapper;
using VelorusNet8.Application.Dto.Branchs;
using VelorusNet8.Application.Interface;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Services.Branchs;

namespace VelorusNet8.Application.Service;

public class BranchService : IBranchService
{
    private readonly IBranchDomainService _branchDomainService;
    private readonly IMapper _mapper;

    public BranchService(IBranchDomainService branchDomainService, IMapper mapper)
    {
        _branchDomainService = branchDomainService;
        _mapper = mapper;
    }

    public async Task<int> CreateBranchAsync(CreateBranchDto dto, CancellationToken cancellationToken)
    {
        var branch = _mapper.Map<BranchEntity>(dto);
        await _branchDomainService.CreateAsync(branch, cancellationToken);
        // Genellikle ID döndürülür; burada ID'yi nasıl alacağınıza karar vermeniz gerekir
        return 0; // veya gerçek oluşturulan ID
    }

    public async Task UpdateBranchAsync(UpdateBranchDto dto, CancellationToken cancellationToken)
    {
        var branch = _mapper.Map<BranchEntity>(dto);
        await _branchDomainService.UpdateAsync(branch, cancellationToken);
    }

    public async Task DeleteBranchAsync(string branchCode, CancellationToken cancellationToken)
    {
        await _branchDomainService.DeleteAsync(branchCode, cancellationToken);
    }

    public async Task<BranchDto> GetBranchByIdAsync(int branchId, CancellationToken cancellationToken)
    {
        var branch = await _branchDomainService.GetByIdAsync(branchId, cancellationToken);
        return _mapper.Map<BranchDto>(branch);
    }

    public async Task<IEnumerable<BranchDto>> GetAllBranchesAsync(CancellationToken cancellationToken)
    {
        var branches = await _branchDomainService.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BranchDto>>(branches);
    }
}