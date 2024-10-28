using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VelorusNet8.Application.DTOs.AngularDersleri;
using VelorusNet8.Application.Service.AngularCustomer;
using FluentValidation;
using VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;
using VelorusNet8.Application.Interface.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.WebApi.Controllers;

[ApiController]
[Route("api/AngularCustomer")]
public class AngularCustomerController : ControllerBase
{
    private readonly IAngularCustomerService _angularcustomerService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediatR;
    private readonly IAngularCustomerQueries _customerQueries; // Yeni eklenen


    public AngularCustomerController(IAngularCustomerService angularcustomerService, IMediator mediatR, IMapper mapper, IAngularCustomerQueries customerQueries)
    {
        _angularcustomerService = angularcustomerService;
        _mediatR = mediatR;
        _mapper = mapper;
        _customerQueries = customerQueries;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        try
        { 
            var angularCustomers = await _angularcustomerService.GetAllAngularCustomersAsync(cancellationToken);
            return Ok(angularCustomers);
        }
        catch (Exception ex)
        {
            // Hata mesajını loglayın veya döndürün
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var angularcustomers = await _angularcustomerService.GetAngularCustomerByIdAsync(id, cancellationToken);
        if (angularcustomers == null)
        {
            return NotFound();
        }
        return Ok(angularcustomers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAngularCustomer([FromBody] AngularCustomerDto createAngularCustomerDto, CancellationToken cancellationToken)
    {
        if (createAngularCustomerDto == null)
        {
            return BadRequest("Kullanıcı bilgileri eksik.");
        }

        try
        {
            // DTO'yu CreateAngularCustomerCommand'e mapleyin
            var createCommand = _mapper.Map<CreateAngularCustomerCommand>(createAngularCustomerDto);

            // Servis kullanarak kullanıcıyı oluşturun
            int createdCustomerId = await _angularcustomerService.CreateAngularCustomerAsync(createCommand, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = createdCustomerId }, createCommand);
        }
        catch (FluentValidation.ValidationException ex)
        {
            // Doğrulama hatalarını yakalayıp, kullanıcıya geri döndürüyoruz
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation failed", Errors = errors });
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAngularCustomer(int id, [FromBody] AngularCustomerDto updateAngularCustomerDto, CancellationToken cancellationToken)
    {
        if (id != updateAngularCustomerDto.id)
        {
            return BadRequest("Müşteri ID'si uyuşmuyor.");
        }

        try
        {
            // DTO'yu UpdateAngularCustomerCommand'e mapleyin
         
            var updateCommand = _mapper.Map<UpdateAngularCustomerCommand>(updateAngularCustomerDto);
            updateCommand.id = id; // URL'den gelen ID'yi command'e aktarın
            // Servis kullanarak kullanıcıyı güncelleyin (void dönüş varsa var ile atama yapmayın)
            await _angularcustomerService.UpdateAngularCustomerAsync(updateCommand, cancellationToken);

            return Ok(new { message = "Customer updated successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }




    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
    {
        //await _userAccountRepository.DeleteAsync(id, cancellationToken);
        await _angularcustomerService.DeleteAngularCustomerAsync(id, cancellationToken);
        return NoContent();
    }

    // Yeni endpoint
    [HttpGet("getpaged")]
    public async Task<IActionResult> GetPaged(
        [FromQuery] PaginationRequestDto request,
        CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"Controller - Sort Column: {request.SortColumn}");
            Console.WriteLine($"Controller - Sort Direction: {request.SortDirection}"); 

            var result = await _customerQueries.GetPaginatedAsync(request, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            // Hata mesajını loglayın
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }


}
