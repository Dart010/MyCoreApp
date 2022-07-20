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
    public class Masters1Controller : ControllerBase
    {
        private readonly MyCoreTourContext _context;

        public Masters1Controller(MyCoreTourContext context)
        {
            _context = context;
        }

        // GET: api/Masters1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Master>>> GetMaster([FromQuery] string masterToSearch)        //[FromQuery] string masterToSearch
        {
            // return await _context.Master.ToListAsync();
            IQueryable<Master> mastersFound = _context.Master;
            if (!String.IsNullOrEmpty(masterToSearch))
            {
                mastersFound = mastersFound.Where(m => m.Name.ToLower().Contains(masterToSearch.Trim().ToLower()));
            }
            return await mastersFound.ToListAsync();
        }

        //[HttpGet("{masterToSearch}")]
        //public async Task<ActionResult<IEnumerable<Master>>> SearchMaster(string masterToSearch)
        //{
        //    IQueryable<Master> mastersFound = _context.Master;
        //    if (String.IsNullOrEmpty(masterToSearch))
        //    {
        //        return new List<Master>();
        //    }
        //    mastersFound = mastersFound.Where(m => m.Name.ToLower().Contains(masterToSearch.Trim().ToLower()));
        //    return await mastersFound.ToListAsync();
        //}

        // GET: api/Masters1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Master>> GetMaster(Guid id)
        {
            var master = await _context.Master.FindAsync(id);

            if (master == null)
            {
                return NotFound();
            }

            return master;
        }

        // PUT: api/Masters1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaster(Guid id, Master master)
        {
            if (id != master.Id)
            {
                return BadRequest();
            }

            _context.Entry(master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterExists(id))
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

        // POST: api/Masters1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Master>> PostMaster(Master master)
        {
            _context.Master.Add(master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaster", new { id = master.Id }, master);
        }

        // DELETE: api/Masters1/5
        [HttpDelete]
        public async Task<IActionResult> DeleteMaster(Guid id)
        {
            var master = await _context.Master.FindAsync(id);
            if (master == null)
            {
                return NotFound();
            }

            _context.Master.Remove(master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterExists(Guid id)
        {
            return _context.Master.Any(e => e.Id == id);
        }
    }
}
