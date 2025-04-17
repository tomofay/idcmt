using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indocement_RESTFullAPI.Models;

namespace Indocement_RESTFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeluhansController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public KeluhansController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/Keluhans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keluhan>>> GetKeluhans()
        {
            return await _context.Keluhans.ToListAsync();
        }

        // GET: api/Keluhans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Keluhan>> GetKeluhan(decimal id)
        {
            var keluhan = await _context.Keluhans.FindAsync(id);

            if (keluhan == null)
            {
                return NotFound();
            }

            return keluhan;
        }

        // PUT: api/Keluhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeluhan(decimal id, Keluhan keluhan)
        {
            if (id != keluhan.Id)
            {
                return BadRequest();
            }

            _context.Entry(keluhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeluhanExists(id))
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

        // POST: api/Keluhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Keluhan>> PostKeluhan(Keluhan keluhan)
        {
            _context.Keluhans.Add(keluhan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeluhan", new { id = keluhan.Id }, keluhan);
        }

        // DELETE: api/Keluhans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKeluhan(decimal id)
        {
            var keluhan = await _context.Keluhans.FindAsync(id);
            if (keluhan == null)
            {
                return NotFound();
            }

            _context.Keluhans.Remove(keluhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KeluhanExists(decimal id)
        {
            return _context.Keluhans.Any(e => e.Id == id);
        }
    }
}
