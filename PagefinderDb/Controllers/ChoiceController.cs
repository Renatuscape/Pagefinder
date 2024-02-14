using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data;
using PagefinderDb.Data.Models;


namespace PagefinderDb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly PagefinderDbContext _db;

        public ChoiceController(PagefinderDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChoice(int id)
        {
            var choice = await _db.Choices
                .Include(c => c.Rewards)
                .Include(c => c.Restrictions)
                .Include(c => c.Requirements)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (choice == null)
            {
                return NotFound();
            }
            return Ok(choice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChoice(Choice choice)
        {
            await _db.Choices.AddAsync(choice);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChoice), new { id = choice.Id }, choice);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateChoice(int id, Choice choice)
        {
            if (id != choice.Id)
            {
                return BadRequest();
            }

            _db.Entry(choice).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChoice(int id)
        {
            var choice = await _db.Choices.FindAsync(id);
            if (choice == null)
            {
                return NotFound();
            }

            _db.Choices.Remove(choice);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
