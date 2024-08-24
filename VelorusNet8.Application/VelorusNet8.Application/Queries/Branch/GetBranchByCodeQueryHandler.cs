using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Application.Dto.Branchs;
using VelorusNet8.Application.Interface;

namespace VelorusNet8.Application.Queries.Branch;

public class GetBranchByCodeQueryHandler : IRequestHandler<GetBranchByCodeQuery, BranchDto>
{
    private readonly IBranchService _branchService;

    public GetBranchByCodeQueryHandler(IBranchService branchService)
    {
        _branchService = branchService;
    }

    public async Task<BranchDto> Handle(GetBranchByCodeQuery request, CancellationToken cancellationToken)
    {
        return await _branchService.GetBranchByIdAsync(request.BranchId, cancellationToken);
    }
}
