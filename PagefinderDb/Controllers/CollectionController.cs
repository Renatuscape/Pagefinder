using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data;
using PagefinderDb.Data.Models;

namespace PagefinderDb.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly PagefinderDbContext _db;

        public CollectionController(PagefinderDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollections()
        {
            var collections = await _db.Collections
                .Include(c => c.User)
                .Include(c => c.Stories)!
                .ThenInclude(s => s.Pages)
                .ToListAsync();
            return Ok(collections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollection(int id)
        {
            var collection = await _db.Collections
                .Include(c => c.User)
                .Include(c => c.Stories)!
                .ThenInclude(s => s.Pages)!
                .ThenInclude(p => p.Choices)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (collection == null)
            {
                return NotFound();
            }
            return Ok(collection);
        }

        //[HttpGet("{collectionId}/stories")]
        //public async Task<IActionResult> GetAllStoriesInCollection(int collectionId)
        //{
        //    var stories = await _db.Stories
        //        .Where(s => s.CollectionId == collectionId)
        //        .Include(s => s.Pages)!
        //        .ToListAsync();
        //    return Ok(stories);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateCollection(Collection collection)
        {
            await _db.Collections.AddAsync(collection);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCollection), new { id = collection.Id }, collection);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollection(int id, Collection collection)
        {
            if (id != collection.Id)
            {
                return BadRequest();
            }

            _db.Entry(collection).State = EntityState.Modified;
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
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await _db.Collections.FindAsync(id);
            if (collection == null)
            {
                return NotFound();
            }
            _db.Collections.Remove(collection);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
