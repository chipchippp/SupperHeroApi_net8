using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi_net8.Data;
using SuperHeroApi_net8.Entities;

namespace SuperHeroApi_net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesController : ControllerBase
    {
        private readonly SuperHeroApi_net8Context _context;

        public SuperHeroesController(SuperHeroApi_net8Context context)
        {
            _context = context;
        }

        // GET: api/SuperHeroes
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHero()
        {
            var heroes = await _context.SuperHero.ToListAsync();
            return Ok(heroes);
        }

        // GET: api/SuperHeroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHero.FindAsync(id);

            if (hero == null)
            {
                return NotFound("Hero not found.");
            }
            return Ok(hero);
        }

        // PUT: api/SuperHeroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(SuperHero updateHero)
        {
            var dbhero = await _context.SuperHero.FindAsync(updateHero.Id);

            if (dbhero == null)
            {
                return NotFound("Hero not found.");
            }

            dbhero.Name = updateHero.Name;
            dbhero.FirstName = updateHero.FirstName;
            dbhero.LastName = updateHero.LastName;
            dbhero.Place = updateHero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHero.ToListAsync());

        }

        // POST: api/SuperHeroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuperHero>> PostSuperHero(SuperHero hero)
        {
            _context.SuperHero.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHero.ToListAsync());
        }

        // DELETE: api/SuperHeroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var superHero = await _context.SuperHero.FindAsync(id);
            if (superHero == null)
            {
                return NotFound("Hero not found.");
            }

            _context.SuperHero.Remove(superHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHero.ToListAsync());
        }

        private bool SuperHeroExists(int id)
        {
            return _context.SuperHero.Any(e => e.Id == id);
        }
    }
}
