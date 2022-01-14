using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab5_Zadanie.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace lab5_Zadanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesItemsController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MoviesItemsController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/MoviesItems
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MoviesItem>> GetMoviesItems(int id)
        {
            var moviesItem = await _context.MoviesItems.FindAsync(id);
            if(moviesItem == null)
            {
                return NotFound();
            }
            return moviesItem;
        }

        // GET: api/MoviesItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Zwraca zadanie o podanym {id}.", "Używa EF FindAsync()")]
        [SwaggerResponse(404, "Nie znaleziono zadania o podanym {id}")]
        public async Task<ActionResult<MoviesItem>> GetMoviesItem([SwaggerParameter("Podaj nr zadania które chcesz odczytać", Required = true)] int id)
        {
            var moviesItem = await _context.MoviesItems.FindAsync(id);

            if (moviesItem == null)
            {
                return NotFound();
            }

            return moviesItem;
        }

        // PUT: api/MoviesItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutMoviesItem(int id, MoviesItem moviesItem)
        {
            if (id != moviesItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(moviesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesItemExists(id))
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

        // POST: api/MoviesItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MoviesItem>> PostMoviesItem(MoviesItem moviesItem)
        {
            _context.MoviesItems.Add(moviesItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoviesItem", new { id = moviesItem.Id }, moviesItem);
        }

        // DELETE: api/MoviesItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMoviesItem(int id)
        {
            var moviesItem = await _context.MoviesItems.FindAsync(id);
            if (moviesItem == null)
            {
                return NotFound();
            }

            _context.MoviesItems.Remove(moviesItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesItemExists(int id)
        {
            return _context.MoviesItems.Any(e => e.Id == id);
        }


    }
}
