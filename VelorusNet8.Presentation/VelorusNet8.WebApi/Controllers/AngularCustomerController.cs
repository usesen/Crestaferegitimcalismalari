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

namespace VelorusNet8.WebApi.Controllers;

[ApiController]
[Route("api/AngularCustomer")]
public class AngularCustomerController : ControllerBase
{
    private readonly IAngularCustomerService _angularcustomerService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediatR;

    public AngularCustomerController(IAngularCustomerService angularcustomerService, IMediator mediatR, IMapper mapper)
    {
        _angularcustomerService = angularcustomerService;
        _mediatR = mediatR;
        _mapper = mapper;
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

            return Ok("Customer updated successfully.");
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
}
