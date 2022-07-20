using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCoreTour.Data;
using MyCoreTour.Models;

namespace MyCoreTour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Heroes1Controller : ControllerBase     
    {
        private readonly MyCoreTourContext _context;

        public Heroes1Controller(MyCoreTourContext context)
        {
            _context = context;
        }

        // GET: api/Heroes1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHero([FromQuery] string heroToSearch)
        {
            // return await _context.Hero.ToListAsync();
            IQueryable<Hero> heroesFound = _context.Hero;
            if(!String.IsNullOrEmpty(heroToSearch))
            {
                heroesFound = heroesFound.Where(h => h.Name.ToLower().Contains(heroToSearch.Trim().ToLower()));
            }
            return await heroesFound.ToListAsync();
        }

        // GET: api/Heroes1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(Guid id)
        {
            var hero = await _context.Hero.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // PUT: api/Heroes1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(Guid id, Hero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            Hero dbHero = await _context.Hero.FirstOrDefaultAsync(x => x.Id == hero.Id);
            dbHero.Name = hero.Name;
            //dbHero.Power = hero.Power;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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

        // POST: api/Heroes1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            _context.Hero.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes1/5
        [HttpDelete]
        public async Task<IActionResult> DeleteHero(Guid id)
        {
            var hero = await _context.Hero.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroExists(Guid id)
        {
            return _context.Hero.Any(e => e.Id == id);
        }
    }
}
