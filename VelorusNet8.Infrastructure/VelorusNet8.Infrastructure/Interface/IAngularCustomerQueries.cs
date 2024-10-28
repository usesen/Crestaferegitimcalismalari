
using VelorusNet8.Application.DTOs.AngularDersleri;

namespace VelorusNet8.Infrastructure.Interface;
// Application katmanında interface
public interface IAngularCustomerQueries
{
    Task<PaginatedResponseDto<AngularCustomerDto>> GetPaginatedAsync(
        PaginationRequestDto request,
        CancellationToken cancellationToken);
}