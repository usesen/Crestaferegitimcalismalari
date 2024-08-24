using MediatR;
using VelorusNet8.Application.Dto.Branchs;

namespace VelorusNet8.Application.Queries.Branch;

public class GetBranchByCodeQuery : IRequest<BranchDto>
{
    public string BranchCode { get; set; }
}