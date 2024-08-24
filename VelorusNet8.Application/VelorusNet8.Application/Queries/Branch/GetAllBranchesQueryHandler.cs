using MediatR;
using VelorusNet8.Application.Dto.Branchs;
using VelorusNet8.Application.Interface;

namespace VelorusNet8.Application.Queries.Branch;

public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, IEnumerable<BranchDto>>
{
    private readonly IBranchService _branchService;

    public GetAllBranchesQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }

    public async Task<IEnumerable<BranchDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
        return await _branchService.GetAllBranchesAsync(cancellationToken);
    }
}