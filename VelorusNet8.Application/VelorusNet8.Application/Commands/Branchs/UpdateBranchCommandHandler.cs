using MediatR;
using VelorusNet8.Domain.Services.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Application.Commands.Branchs;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand>
{
    private readonly IBranchDomainService _branchDomainService;

    public UpdateBranchCommandHandler(IBranchDomainService branchDomainService)
    {
        _branchDomainService = branchDomainService;
    }

    async Task IRequestHandler<UpdateBranchCommand>.Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = new BranchEntity
        {
            BranchCode = request.BranchCode,
            BranchName = request.BranchName,
            Address = request.Address,
            Phone = request.Phone,
            Fax = request.Fax,
            Email = request.Email,
            CommissionRate = request.CommissionRate,
            CommissionAmount = request.CommissionAmount,
            DefaultShrinkageRate = request.DefaultShrinkageRate,
            IsHeadOffice = request.IsHeadOffice,
            IsSalesEnabled = request.IsSalesEnabled,
            IsAutomationIntegrationEnabled = request.IsAutomationIntegrationEnabled
        };

        await _branchDomainService.UpdateAsync(branch, cancellationToken);
    }
}