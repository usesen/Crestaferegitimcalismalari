using MediatR;
using VelorusNet8.Domain.Services.Branchs;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Application.Commands.Branchs;

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, int>
{
    private readonly IBranchDomainService _branchDomainService;

    public CreateBranchCommandHandler(IBranchDomainService branchDomainService)
    {
        _branchDomainService = branchDomainService;
    }

    public async Task<int> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
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

        await _branchDomainService.CreateAsync(branch, cancellationToken);

        // Başarıyla oluşturulduktan sonra dönecek ID (veya başka bir değer)
        // Bu örnekte dönen değeri 0 olarak belirledik
        return 0;
    }
}
