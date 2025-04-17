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
    public class BpjsController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public BpjsController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/Bpjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bpjs>>> GetBpjs()
        {
            return await _context.Bpjs.ToListAsync();
        }

        // GET: api/Bpjs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bpjs>> GetBpjs(decimal id)
        {
            var bpjs = await _context.Bpjs.FindAsync(id);

            if (bpjs == null)
            {
                return NotFound();
            }

            return bpjs;
        }

        // PUT: api/Bpjs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBpjs(decimal id, Bpjs bpjs)
        {
            if (id != bpjs.Id)
            {
                return BadRequest();
            }

            _context.Entry(bpjs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BpjsExists(id))
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

        // POST: api/Bpjs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bpjs>> PostBpjs(Bpjs bpjs)
        {
            _context.Bpjs.Add(bpjs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBpjs", new { id = bpjs.Id }, bpjs);
        }

        // DELETE: api/Bpjs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBpjs(decimal id)
        {
            var bpjs = await _context.Bpjs.FindAsync(id);
            if (bpjs == null)
            {
                return NotFound();
            }

            _context.Bpjs.Remove(bpjs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BpjsExists(decimal id)
        {
            return _context.Bpjs.Any(e => e.Id == id);
        }
    }
}
