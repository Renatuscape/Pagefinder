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
            var story = await _db.Stories.Where(s => s.Id == page.StoryId)
                .FirstOrDefaultAsync();

            if (story == null)
            {
                return BadRequest();
            }

            await _db.Entry(story).Collection(s => s.Pages!).LoadAsync(); // Ensure Pages collection is loaded

            if (story.Pages != null)
            {
                page.Order = story.Pages.Count;
            }
            else
            {
                page.Order = 0;
            }

            page.Story = story;

            await _db.Pages.AddAsync(page);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPage), new { storyId = page.StoryId, id = page.Id }, page);
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
                // Save changes to the database
                await _db.SaveChangesAsync();

                // Retrieve the updated object from the database
                var updatedCollection = await _db.Collections.FindAsync(id);

                // Return the updated object
                return Ok(updatedCollection);
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

            var pagesInStory = await _db.Pages
                .Where(p => p.StoryId == page.StoryId)
                .ToListAsync();

            foreach (var p in pagesInStory)
            {
                if (p.Order > page.Order)
                {
                    p.Order--;
                    _db.Entry(p).State = EntityState.Modified;
                }
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
