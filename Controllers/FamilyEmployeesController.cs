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
    public class FamilyEmployeesController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public FamilyEmployeesController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/FamilyEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyEmployee>>> GetFamilyEmployees()
        {
            return await _context.FamilyEmployees.ToListAsync();
        }

        // GET: api/FamilyEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyEmployee>> GetFamilyEmployee(decimal id)
        {
            var familyEmployee = await _context.FamilyEmployees.FindAsync(id);

            if (familyEmployee == null)
            {
                return NotFound();
            }

            return familyEmployee;
        }

        // PUT: api/FamilyEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyEmployee(decimal id, FamilyEmployee familyEmployee)
        {
            if (id != familyEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(familyEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyEmployeeExists(id))
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

        // POST: api/FamilyEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FamilyEmployee>> PostFamilyEmployee(FamilyEmployee familyEmployee)
        {
            _context.FamilyEmployees.Add(familyEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilyEmployee", new { id = familyEmployee.Id }, familyEmployee);
        }

        // DELETE: api/FamilyEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyEmployee(decimal id)
        {
            var familyEmployee = await _context.FamilyEmployees.FindAsync(id);
            if (familyEmployee == null)
            {
                return NotFound();
            }

            _context.FamilyEmployees.Remove(familyEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FamilyEmployeeExists(decimal id)
        {
            return _context.FamilyEmployees.Any(e => e.Id == id);
        }
    }
}
