using Microsoft.AspNetCore.Mvc;
using VelorusNet8.Application.DTOs.Group;
using VelorusNet8.Application.Interface.Group;

namespace VelorusNet8.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserGroupController : ControllerBase
{
    private readonly IUserGroupService _userGroupService;

    public UserGroupController(IUserGroupService userGroupService)
    {
        _userGroupService = userGroupService;
    }

    // Tüm grupları listeleme
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var groups = await _userGroupService.GetAllAsync(cancellationToken);
        return Ok(groups);
    }

    // Grup detayını alma
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var group = await _userGroupService.GetByIdAsync(id, cancellationToken);
        if (group == null)
        {
            return NotFound();
        }
        return Ok(group);
    }

    // Yeni grup oluşturma
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserGroupDto createUserGroupDto, CancellationToken cancellationToken)
    {
        if (createUserGroupDto == null)
        {
            return BadRequest("Invalid group data.");
        }

        var createdGroupId = await _userGroupService.CreateUserGroupAsync(createUserGroupDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = createdGroupId }, createdGroupId);
    }

    // Grup güncelleme
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserGroupDto updateUserGroupDto, CancellationToken cancellationToken)
    {
        if (updateUserGroupDto == null || id != updateUserGroupDto.Id)
        {
            return BadRequest("Invalid group data.");
        }

        var updatedGroupId = await _userGroupService.UpdateUserGroupAsync(updateUserGroupDto, cancellationToken);
        return Ok(updatedGroupId);
    }

    // Grup silme
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _userGroupService.DeleteUserGroupAsync(id, cancellationToken);
        return NoContent();
    }
}
