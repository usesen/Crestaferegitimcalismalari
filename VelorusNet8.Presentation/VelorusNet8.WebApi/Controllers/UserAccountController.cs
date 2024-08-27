using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Interface;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.WepApi.WpDto.WpUser;

namespace VelorusNet8.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAccountController : ControllerBase
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IUserAccountService _userAccountService;
    private readonly IMapper _mapper;
    public UserAccountController(IUserAccountRepository userAccountRepository, IUserAccountService userAccountService, IMapper mapper)
    {
        _userAccountRepository = userAccountRepository;
        _userAccountService = userAccountService;
        _mapper = mapper;
    }
    // Kullanıcı oluşturma işlemi
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserAcountDtoWpa createUserAcountDtoWpa, CancellationToken cancellationToken)
    {
        if (createUserAcountDtoWpa == null)
        {
            return BadRequest("Kullanıcı bilgileri eksik.");
        }

        var userAccount = new UserAccount
        {   
            UserName = createUserAcountDtoWpa.UserName,
            Email = createUserAcountDtoWpa.Email,
            PasswordHash = createUserAcountDtoWpa.PasswordHash,
            IsActive = createUserAcountDtoWpa.IsActive
        };

        var createUserAccount = _mapper.Map<CreateUserAccountDto>(userAccount);
        await _userAccountService.CreateUserAsync(createUserAccount, cancellationToken);
       // await _userAccountRepository.AddAsync(userAccount, cancellationToken);

        return CreatedAtAction(nameof(GetUserById), new { id = userAccount.UserId }, userAccount);
    }

    // Kullanıcıyı ID'ye göre getir
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
    {
        var user = await _userAccountRepository.GetByIdAsync(id, cancellationToken);
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
        var users = await _userAccountRepository.GetAllAsync(cancellationToken);
        return Ok(users);
    }

    // Kullanıcı güncelleme işlemi
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserAccount userAccount, CancellationToken cancellationToken)
    {
        if (userAccount == null || id != userAccount.UserId)
        {
            return BadRequest("Kullanıcı bilgileri geçersiz.");
        }

        await _userAccountRepository.UpdateAsync(userAccount, cancellationToken);

        return Ok(userAccount);
    }

    // Kullanıcı silme işlemi
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
    {
        await _userAccountRepository.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}

 
