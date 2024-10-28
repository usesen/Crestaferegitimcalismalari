using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Application.DTOs.AngularDersleri;

namespace VelorusNet8.Infrastructure.Queries.GetPaginatedCustomers;

// Query
public class GetPaginatedCustomersQuery : IRequest<PaginatedResponseDto<AngularCustomerDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SortColumn { get; set; } = "id";     // Eklendi
    public string SortDirection { get; set; } = "desc"; // Eklendi
}
