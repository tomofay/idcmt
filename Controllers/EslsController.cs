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
    public class EslsController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public EslsController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/Esls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Esl>>> GetEsls()
        {
            return await _context.Esls.ToListAsync();
        }

        // GET: api/Esls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Esl>> GetEsl(decimal id)
        {
            var esl = await _context.Esls.FindAsync(id);

            if (esl == null)
            {
                return NotFound();
            }

            return esl;
        }

        // PUT: api/Esls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEsl(decimal id, Esl esl)
        {
            if (id != esl.Id)
            {
                return BadRequest();
            }

            _context.Entry(esl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EslExists(id))
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

        // POST: api/Esls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Esl>> PostEsl(Esl esl)
        {
            _context.Esls.Add(esl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEsl", new { id = esl.Id }, esl);
        }

        // DELETE: api/Esls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEsl(decimal id)
        {
            var esl = await _context.Esls.FindAsync(id);
            if (esl == null)
            {
                return NotFound();
            }

            _context.Esls.Remove(esl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EslExists(decimal id)
        {
            return _context.Esls.Any(e => e.Id == id);
        }
    }
}
