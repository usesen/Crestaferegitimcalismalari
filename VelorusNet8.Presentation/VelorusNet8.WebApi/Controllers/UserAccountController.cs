using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.WepApi.WpDto.WpUser;
using FluentValidation;
using VelorusNet8.Application.Commands.UserAccount;
using MediatR;
using VelorusNet8.Application.Interface.User;


namespace VelorusNet8.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAccountController : ControllerBase
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IUserAccountService _userAccountService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediatR;

    public UserAccountController(IUserAccountRepository userAccountRepository, IUserAccountService userAccountService, IMapper mapper, IMediator mediatR)
    {
        _userAccountRepository = userAccountRepository;
        _userAccountService = userAccountService;
        _mapper = mapper;
        _mediatR = mediatR;
    }
    // Kullanıcı oluşturma işlemi
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserAcountDtoWpa createUserAcountDtoWpa, CancellationToken cancellationToken)
    {
        if (createUserAcountDtoWpa == null)
        {
            return BadRequest("Kullanıcı bilgileri eksik.");
        }
        try
        {

            var createUserAccountDto = _mapper.Map<CreateUserAccountDto>(createUserAcountDtoWpa);
            // Servis kullanarak kullanıcıyı oluşturun
            int GetUserById = await _userAccountService.CreateUserAsync(createUserAccountDto, cancellationToken);

            return CreatedAtAction(nameof(GetUserById), new { id = createUserAcountDtoWpa.UserId }, createUserAcountDtoWpa);
        }
        catch (ValidationException ex)
        {
            // Doğrulama hatalarını yakalayıp, kullanıcıya geri döndürüyoruz
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList();
            return BadRequest(new { Message = "Validation failed", Errors = errors });
        }
    }
    // Kullanıcı güncelleme işlemi
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserAccountCommand command, CancellationToken cancellationToken)
    {
        if (command == null || id != command.UserId)
        {
            return BadRequest("Kullanıcı bilgileri geçersiz.");
        }

        var updatedUserId = await _mediatR.Send(command, cancellationToken);

        return Ok(updatedUserId);
    }

    // Kullanıcıyı ID'ye göre getir
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
    {
        //var user = await _userAccountRepository.GetByIdAsync(id, cancellationToken);
        var user = await _userAccountService.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }

        return Ok(user);
    }

    // Tüm kullanıcıları getir
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        //var users = await _userAccountRepository.GetAllAsync(cancellationToken);
        var users = await _userAccountService.GetAllAsync(cancellationToken);
        return Ok(users);
    }


    // Kullanıcı silme işlemi
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
    {
        //await _userAccountRepository.DeleteAsync(id, cancellationToken);
        await _userAccountService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}

 
