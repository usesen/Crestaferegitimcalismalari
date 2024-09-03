using Microsoft.AspNetCore.Mvc;
using VelorusNet8.Application.DTOs.Group;
using VelorusNet8.Application.Interface.Group;

namespace VelorusNet8.WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserAccountGroupController : ControllerBase
{
    private readonly IUserAccountGroupService _userAccountGroupService;

    public UserAccountGroupController(IUserAccountGroupService userAccountGroupService)
    {
        _userAccountGroupService = userAccountGroupService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAccountGroup([FromBody] CreateUserAccountGroupDto dto, CancellationToken cancellationToken)
    {
        var id = await _userAccountGroupService.CreateUserAccountGroupAsync(dto.UserId, dto.GroupId, cancellationToken);
        return CreatedAtAction(nameof(GetUserAccountGroupById), new { id }, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAccountGroup(int id, CancellationToken cancellationToken)
    {
        await _userAccountGroupService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAccountGroupById(int id, CancellationToken cancellationToken)
    {
        var result = await _userAccountGroupService.GetByIdAsync(id, cancellationToken);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetGroupsByUserId(int userId, CancellationToken cancellationToken)
    {
        var result = await _userAccountGroupService.GetGroupsByUserIdAsync(userId, cancellationToken);
        return Ok(result);
    }

    [HttpGet("group/{groupId}")]
    public async Task<IActionResult> GetUsersByGroupId(int groupId, CancellationToken cancellationToken)
    {
        var result = await _userAccountGroupService.GetUsersByGroupIdAsync(groupId, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("group/{groupId}")]
    public async Task<IActionResult> RemoveByGroupId(int groupId, CancellationToken cancellationToken)
    {
        await _userAccountGroupService.RemoveByGroupIdAsync(groupId, cancellationToken);
        return NoContent();
    }
}
