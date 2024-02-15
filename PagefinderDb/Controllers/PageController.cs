using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data;
using PagefinderDb.Data.Models;

namespace PagefinderDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase
    {
        private readonly PagefinderDbContext _db;

        public PageController(PagefinderDbContext db)
        {
            _db = db;
        }

        [HttpGet("{storyId}")]
        public async Task<IActionResult> GetAllPages(int storyId)
        {
            var pages = await _db.Pages
                .Where(p => p.StoryId == storyId)
                .Include(p => p.Choices)
                .ToListAsync();
            return Ok(pages);
        }

        [HttpGet("{storyId}/{id}")]
        public async Task<IActionResult> GetPage(int storyId, int id)
        {
            var page = await _db.Pages
                .Where(p => p.StoryId == storyId)
                .Include(p => p.Choices)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (page == null)
            {
                return NotFound();
            }
            return Ok(page);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePage(Page page)
        {
            await _db.Pages.AddAsync(page);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPage), new { id = page.Id}, page);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePage(int id, Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }

            _db.Entry(page).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePage(int id)
        {
            var page = await _db.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            _db.Pages.Remove(page);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        private bool PageExists(int id)
        {
            return _db.Pages.Any(e => e.Id == id);
        }
    }
}
