using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data;
using PagefinderDb.Data.Models;

namespace PagefinderDb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {
        private readonly PagefinderDbContext _db;

        public StoryController(PagefinderDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStories()
        {
            var stories = await _db.Stories
                .ToListAsync();
            return Ok(stories);
        }

        [HttpGet("{collectionId}")]
        public async Task<IActionResult> GetAllStoriesInCollection(int collectionId)
        {
            var stories = await _db.Stories
                .Where(s => s.CollectionId == collectionId)
                .Include(s => s.Pages)!
                .ToListAsync();
            return Ok(stories);
        }

        [HttpGet("/read")]
        public async Task<IActionResult> GetStory(int id)
        {
            var story = await _db.Stories
                .Include(s => s.Collection)!
                .ThenInclude(c => c!.User)!
                .Include(s => s.Pages)!
                     .ThenInclude(p => p.Choices)!
                            .ThenInclude(choice => choice!.Rewards)! // Include content for Choice
                .Include(s => s.Pages)!
                    .ThenInclude(p => p.Choices)!
                            .ThenInclude(choice => choice!.Restrictions)! // Include Restrictions for Choice
                .Include(s => s.Pages)!
                    .ThenInclude(p => p.Choices)!
                            .ThenInclude(choice => choice!.Requirements) // Include Requirements for Choice

                .FirstOrDefaultAsync(s => s.Id == id);

            if (story == null)
            {
                return NotFound();
            }

            return Ok(story);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStory(Story story)
        {
            await _db.Stories.AddAsync(story);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStory), new { id = story.Id }, story);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStory(int id, Story story)
        {
            if (id != story.Id)
            {
                return BadRequest();
            }

            _db.Entry(story).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory(int id)
        {
            var story = await _db.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            _db.Stories.Remove(story);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
