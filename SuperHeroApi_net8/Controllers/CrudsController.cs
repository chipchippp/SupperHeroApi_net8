using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi_net8.Data;
using SuperHeroApi_net8.Entity;

namespace SuperHeroApi_net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudsController : ControllerBase
    {
        private readonly SuperHeroApi_net8Context _context;

        public CrudsController(SuperHeroApi_net8Context context)
        {
            _context = context;
        }

        // GET: api/Cruds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crud>>> GetCrud()
        {
            return await _context.Crud.ToListAsync();
        }

        // GET: api/Cruds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crud>> GetCrud(int id)
        {
            var crud = await _context.Crud.FindAsync(id);

            if (crud == null)
            {
                return NotFound();
            }

            return crud;
        }

        // PUT: api/Cruds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrud(int id, Crud crud)
        {
            if (id != crud.Id)
            {
                return BadRequest();
            }

            _context.Entry(crud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrudExists(id))
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

        // POST: api/Cruds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Crud>> PostCrud(Crud crud)
        {
            _context.Crud.Add(crud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrud", new { id = crud.Id }, crud);
        }

        // DELETE: api/Cruds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrud(int id)
        {
            var crud = await _context.Crud.FindAsync(id);
            if (crud == null)
            {
                return NotFound();
            }

            _context.Crud.Remove(crud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CrudExists(int id)
        {
            return _context.Crud.Any(e => e.Id == id);
        }
    }
}
