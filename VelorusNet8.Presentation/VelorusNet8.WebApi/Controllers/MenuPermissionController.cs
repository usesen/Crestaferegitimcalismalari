using Microsoft.AspNetCore.Mvc;

namespace VelorusNet8.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VelorusNet8.Application.DTOs.Menu;
using VelorusNet8.Application.Interface.Menus;

[ApiController]
[Route("api/[controller]")]
public class MenuPermissionController : ControllerBase
{
    private readonly IMenuPermissionService _menuPermissionService;

    public MenuPermissionController(IMenuPermissionService menuPermissionService)
    {
        _menuPermissionService = menuPermissionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenuPermissionById(int id, CancellationToken cancellationToken)
    {
        var menuPermission = await _menuPermissionService.GetByIdAsync(id, cancellationToken);
        if (menuPermission == null)
        {
            return NotFound();
        }
        return Ok(menuPermission);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMenuPermissions(CancellationToken cancellationToken)
    {
        var menuPermissions = await _menuPermissionService.GetAllAsync(cancellationToken);
        return Ok(menuPermissions);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenuPermission([FromBody] MenuPermissionDto menuPermissionDto, CancellationToken cancellationToken)
    {
        await _menuPermissionService.AddAsync(menuPermissionDto, cancellationToken);
        return CreatedAtAction(nameof(GetMenuPermissionById), new { id = menuPermissionDto.PermissionId }, menuPermissionDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenuPermission(int id, [FromBody] MenuPermissionDto menuPermissionDto, CancellationToken cancellationToken)
    {
        if (id != menuPermissionDto.PermissionId)
        {
            return BadRequest("Menu Permission ID mismatch.");
        }

        await _menuPermissionService.UpdateAsync(menuPermissionDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenuPermission(int id, CancellationToken cancellationToken)
    {
        await _menuPermissionService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetMenuPermissionByTitle(string title, CancellationToken cancellationToken)
    {
        var menuPermission = await _menuPermissionService.GetByTitleAsync(title, cancellationToken);
        if (menuPermission == null)
        {
            return NotFound();
        }
        return Ok(menuPermission);
    }
}
