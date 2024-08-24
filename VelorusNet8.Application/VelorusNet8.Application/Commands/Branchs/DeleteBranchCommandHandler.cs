using MediatR;
using VelorusNet8.Domain.Services.Branchs;

namespace VelorusNet8.Application.Commands.Branchs;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand>
{
    private readonly IBranchDomainService _branchDomainService;

    public DeleteBranchCommandHandler(IBranchDomainService branchDomainService)
    {
        _branchDomainService = branchDomainService;
    }

 
    async Task IRequestHandler<DeleteBranchCommand>.Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        await _branchDomainService.DeleteAsync(request.BranchCode, cancellationToken);
      
    }
}