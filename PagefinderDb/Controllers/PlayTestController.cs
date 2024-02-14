using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data;
using PagefinderDb.Data.Models;

namespace PagefinderDb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayTestController : ControllerBase
    {
        private readonly PagefinderDbContext _db;

        public PlayTestController(PagefinderDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayTest(int id)
        {
            var playTest = await _db.PlayTests
                .Include(pt => pt.Story)
                .FirstOrDefaultAsync(pt => pt.Id == id);
            if (playTest == null)
            {
                return NotFound();
            }
            return Ok(playTest);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayTest(PlayTest playTest)
        {
            await _db.PlayTests.AddAsync(playTest);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayTest), new { id = playTest.Id }, playTest);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlayTest(int id, PlayTest playTest)
        {
            if (id != playTest.Id)
            {
                return BadRequest();
            }

            _db.Entry(playTest).State = EntityState.Modified;

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
        public async Task<IActionResult> DeletePlayTest(int id)
        {
            var playTest = await _db.PlayTests.FindAsync(id);
            if (playTest == null)
            {
                return NotFound();
            }

            _db.PlayTests.Remove(playTest);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
