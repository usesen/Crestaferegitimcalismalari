using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserAccountController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/UserAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAccount>> GetUserAccount(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return userAccount;
        }

        // POST: api/UserAccount
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccount(UserAccount userAccount)
        {
            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserAccount), new { id = userAccount.UserId }, userAccount);
        }

        // PUT: api/UserAccount/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAccount(int id, UserAccount userAccount)
        {
            if (id != userAccount.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/UserAccount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _context.UserAccounts.Remove(userAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAccountExists(int id)
        {
            return _context.UserAccounts.Any(e => e.UserId == id);
        }
    }
}
