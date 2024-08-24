using MediatR;
using VelorusNet8.Application.Dto.Branchs;

namespace VelorusNet8.Application.Queries.Branch;

public class GetAllBranchesQuery : IRequest<IEnumerable<BranchDto>>
{
}