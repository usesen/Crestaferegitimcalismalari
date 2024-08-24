using VelorusNet8.Application.Dto.Branchs;

namespace VelorusNet8.Application.Interface;

public interface IBranchService
{
    Task<int> CreateBranchAsync(CreateBranchDto dto, CancellationToken cancellationToken);
    Task UpdateBranchAsync(UpdateBranchDto dto, CancellationToken cancellationToken);
    Task DeleteBranchAsync(string branchCode, CancellationToken cancellationToken);
    Task<BranchDto> GetBranchByCodeAsync(string branchCode, CancellationToken cancellationToken);
    Task<IEnumerable<BranchDto>> GetAllBranchesAsync(CancellationToken cancellationToken);

}
