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
    public class PlantDivisionsController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public PlantDivisionsController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/PlantDivisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantDivision>>> GetPlantDivisions()
        {
            return await _context.PlantDivisions.ToListAsync();
        }

        // GET: api/PlantDivisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDivision>> GetPlantDivision(decimal id)
        {
            var plantDivision = await _context.PlantDivisions.FindAsync(id);

            if (plantDivision == null)
            {
                return NotFound();
            }

            return plantDivision;
        }

        // PUT: api/PlantDivisions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantDivision(decimal id, PlantDivision plantDivision)
        {
            if (id != plantDivision.Id)
            {
                return BadRequest();
            }

            _context.Entry(plantDivision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantDivisionExists(id))
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

        // POST: api/PlantDivisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlantDivision>> PostPlantDivision(PlantDivision plantDivision)
        {
            _context.PlantDivisions.Add(plantDivision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantDivision", new { id = plantDivision.Id }, plantDivision);
        }

        // DELETE: api/PlantDivisions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantDivision(decimal id)
        {
            var plantDivision = await _context.PlantDivisions.FindAsync(id);
            if (plantDivision == null)
            {
                return NotFound();
            }

            _context.PlantDivisions.Remove(plantDivision);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantDivisionExists(decimal id)
        {
            return _context.PlantDivisions.Any(e => e.Id == id);
        }
    }
}
