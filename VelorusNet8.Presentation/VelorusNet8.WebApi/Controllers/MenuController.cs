using Microsoft.AspNetCore.Mvc;

namespace VelorusNet8.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VelorusNet8.Application.DTOs.Menu;
using VelorusNet8.Application.Interface.Menus;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMenuById(int id, CancellationToken cancellationToken)
    {
        var menu = await _menuService.GetByIdAsync(id, cancellationToken);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMenus(CancellationToken cancellationToken)
    {
        var menus = await _menuService.GetAllAsync(cancellationToken);
        return Ok(menus);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu([FromBody] MenuDto menuDto, CancellationToken cancellationToken)
    {
        await _menuService.AddAsync(menuDto, cancellationToken);
        return CreatedAtAction(nameof(GetMenuById), new { id = menuDto.MenuId }, menuDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenu(int id, [FromBody] MenuDto menuDto, CancellationToken cancellationToken)
    {
        if (id != menuDto.MenuId)
        {
            return BadRequest("Menu ID mismatch.");
        }

        await _menuService.UpdateAsync(menuDto, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(int id, CancellationToken cancellationToken)
    {
        await _menuService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("title/{title}")]
    public async Task<IActionResult> GetMenuByTitle(string title, CancellationToken cancellationToken)
    {
        var menu = await _menuService.GetByTitleAsync(title, cancellationToken);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpGet("{id}/permissions")]
    public async Task<IActionResult> GetMenuWithPermissions(int id, CancellationToken cancellationToken)
    {
        var menu = await _menuService.GetMenuWithPermissionsAsync(id, cancellationToken);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }
}
