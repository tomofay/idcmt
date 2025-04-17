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
    public class KonsultasisController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public KonsultasisController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/Konsultasis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Konsultasi>>> GetKonsultasis()
        {
            return await _context.Konsultasis.ToListAsync();
        }

        // GET: api/Konsultasis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Konsultasi>> GetKonsultasi(decimal id)
        {
            var konsultasi = await _context.Konsultasis.FindAsync(id);

            if (konsultasi == null)
            {
                return NotFound();
            }

            return konsultasi;
        }

        // PUT: api/Konsultasis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKonsultasi(decimal id, Konsultasi konsultasi)
        {
            if (id != konsultasi.Id)
            {
                return BadRequest();
            }

            _context.Entry(konsultasi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KonsultasiExists(id))
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

        // POST: api/Konsultasis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Konsultasi>> PostKonsultasi(Konsultasi konsultasi)
        {
            _context.Konsultasis.Add(konsultasi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKonsultasi", new { id = konsultasi.Id }, konsultasi);
        }

        // DELETE: api/Konsultasis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKonsultasi(decimal id)
        {
            var konsultasi = await _context.Konsultasis.FindAsync(id);
            if (konsultasi == null)
            {
                return NotFound();
            }

            _context.Konsultasis.Remove(konsultasi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KonsultasiExists(decimal id)
        {
            return _context.Konsultasis.Any(e => e.Id == id);
        }
    }
}
