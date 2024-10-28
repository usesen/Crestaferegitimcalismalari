using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Application.DTOs.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Queries.GetPaginatedCustomers;

namespace VelorusNet8.Application.Queries.GetPaginatedCustomers;

public class GetPaginatedCustomersQueryHandler :
    IRequestHandler<GetPaginatedCustomersQuery, PaginatedResponseDto<AngularCustomerDto>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetPaginatedCustomersQueryHandler(
        AppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedResponseDto<AngularCustomerDto>> Handle(
    GetPaginatedCustomersQuery request,
    CancellationToken cancellationToken)
    {
        // Debug için
        Console.WriteLine($"Sort Column: {request.SortColumn}");
        Console.WriteLine($"Sort Direction: {request.SortDirection}");

        // Sadece toplam sayıyı al
        var totalItems = await _context.AngularCustomers.CountAsync(cancellationToken);

        // Sadece gerekli sayfadaki verileri çek
        IQueryable<AngularCustomer> query = _context.AngularCustomers; // IQueryable olarak tanımla
        
        // Debug için
        Console.WriteLine($"Initial Query: {query.ToQueryString()}");
       
        // Sıralama
        if (request.SortDirection?.ToLower() == "asc")
        {
            query = request.SortColumn?.ToLower() switch
            {
                
                "name" => query.OrderBy(x => x.firstName),
                "email" => query.OrderBy(x => x.email),
                "company" => query.OrderBy(x => x.company),
                "city" => query.OrderBy(x => x.city),
                "country" => query.OrderBy(x => x.country),
                _ => query.OrderByDescending(x => x.id) // Varsayılan sıralama
            };
        }
        else
        {
            query = request.SortColumn?.ToLower() switch
            {
           
                "name" => query.OrderByDescending(x => x.firstName),
                "email" => query.OrderByDescending(x => x.email),
                "company" => query.OrderByDescending(x => x.company),
                "city" => query.OrderByDescending(x => x.city),
                "country" => query.OrderByDescending(x => x.country),
                _ => query.OrderByDescending(x => x.id) // Varsayılan sıralama
            };
        }

        // Debug için
        Console.WriteLine($"Final Query: {query.ToQueryString()}");

        var pagedItems = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => _mapper.Map<AngularCustomerDto>(x))
            .ToListAsync(cancellationToken);

        return new PaginatedResponseDto<AngularCustomerDto>
        {
            Items = pagedItems,
            TotalItems = totalItems,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize),
            HasNext = request.PageNumber < (int)Math.Ceiling(totalItems / (double)request.PageSize),
            HasPrevious = request.PageNumber > 1
        };
    }

}