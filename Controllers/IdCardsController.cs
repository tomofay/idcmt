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
    public class IdCardsController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public IdCardsController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/IdCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdCard>>> GetIdCards()
        {
            return await _context.IdCards.ToListAsync();
        }

        // GET: api/IdCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdCard>> GetIdCard(decimal id)
        {
            var idCard = await _context.IdCards.FindAsync(id);

            if (idCard == null)
            {
                return NotFound();
            }

            return idCard;
        }

        // PUT: api/IdCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdCard(decimal id, IdCard idCard)
        {
            if (id != idCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(idCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdCardExists(id))
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

        // POST: api/IdCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdCard>> PostIdCard(IdCard idCard)
        {
            _context.IdCards.Add(idCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdCard", new { id = idCard.Id }, idCard);
        }

        // DELETE: api/IdCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdCard(decimal id)
        {
            var idCard = await _context.IdCards.FindAsync(id);
            if (idCard == null)
            {
                return NotFound();
            }

            _context.IdCards.Remove(idCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdCardExists(decimal id)
        {
            return _context.IdCards.Any(e => e.Id == id);
        }
    }
}
