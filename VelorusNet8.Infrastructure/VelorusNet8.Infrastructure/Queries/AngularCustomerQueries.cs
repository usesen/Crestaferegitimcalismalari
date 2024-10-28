using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VelorusNet8.Application.DTOs.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Infrastructure.Queries;

// Infrastructure katmanında implementasyon
public class AngularCustomerQueries : IAngularCustomerQueries
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AngularCustomerQueries(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedResponseDto<AngularCustomerDto>> GetPaginatedAsync(
          PaginationRequestDto request,
          CancellationToken cancellationToken)
    {
        Console.WriteLine($"Query Service - Sort Column: {request.SortColumn}");
        Console.WriteLine($"Query Service - Sort Direction: {request.SortDirection}");

        IQueryable<AngularCustomer> query = _context.AngularCustomers;

        // Sadece dolu olan parametrelere göre filtreleme yapalım
        if (!string.IsNullOrWhiteSpace(request.SearchName))
        {
            query = query.Where(x =>
                (x.firstName + " " + x.lastName).Contains(request.SearchName));
        }

        if (!string.IsNullOrWhiteSpace(request.SearchCompany))
        {
            query = query.Where(x => x.company.Contains(request.SearchCompany));
        }

        if (!string.IsNullOrWhiteSpace(request.SearchCountry))
        {
            query = query.Where(x => x.country.Contains(request.SearchCountry));
        }


        var totalItems = await _context.AngularCustomers.CountAsync(cancellationToken);

        

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
                "id" => query.OrderBy(x => x.id)
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
                "id" => query.OrderByDescending(x => x.id)
            };
        }

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