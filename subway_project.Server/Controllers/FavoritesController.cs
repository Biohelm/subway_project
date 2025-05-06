using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using subway_project.Server.Data;
using subway_project.Server.Models;

namespace subway_project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoritesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Favorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorite()
        {
            return await _context.Favorites.Include(f => f.Products).ToListAsync();
        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        // PUT: api/Favorites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorite(int id, Favorite favorite)
        {
            if (id != favorite.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // POST: api/Favorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.Id }, favorite);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
}
