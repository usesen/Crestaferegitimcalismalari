using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BranchController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Branch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchEntity>>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }

        // GET: api/Branch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchEntity>> GetBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return branch;
        }

        // POST: api/Branch
        [HttpPost]
        public async Task<ActionResult<BranchEntity>> PostBranch(BranchEntity branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBranch), new { id = branch.Id }, branch);
        }

        // PUT: api/Branch/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, BranchEntity branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Branch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
