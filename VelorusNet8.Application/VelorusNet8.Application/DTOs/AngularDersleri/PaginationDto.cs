using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelorusNet8.Application.DTOs.AngularDersleri;

// Application/DTOs/Common/PaginationDto.cs
// Application/DTOs/Common/PaginationRequestDto.cs
public class PaginationRequestDto
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public string SortColumn { get; set; } = "id";
    public string SortDirection { get; set; } = "asc";


    // Arama parametreleri
    public string? SearchName { get; set; }
    public string? SearchCompany { get; set; }
    public string? SearchCountry { get; set; }
}

// Application/DTOs/Common/PaginatedResponseDto.cs
public class PaginatedResponseDto<T>
{
    public List<T> Items { get; set; } // IReadOnlyList yerine List kullanıyoruz
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}