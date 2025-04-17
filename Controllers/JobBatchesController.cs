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
    public class JobBatchesController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public JobBatchesController(IndocementDbContext context)
        {
            _context = context;
        }

        // GET: api/JobBatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobBatch>>> GetJobBatches()
        {
            return await _context.JobBatches.ToListAsync();
        }

        // GET: api/JobBatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobBatch>> GetJobBatch(string id)
        {
            var jobBatch = await _context.JobBatches.FindAsync(id);

            if (jobBatch == null)
            {
                return NotFound();
            }

            return jobBatch;
        }

        // PUT: api/JobBatches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobBatch(string id, JobBatch jobBatch)
        {
            if (id != jobBatch.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobBatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobBatchExists(id))
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

        // POST: api/JobBatches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobBatch>> PostJobBatch(JobBatch jobBatch)
        {
            _context.JobBatches.Add(jobBatch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobBatchExists(jobBatch.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobBatch", new { id = jobBatch.Id }, jobBatch);
        }

        // DELETE: api/JobBatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobBatch(string id)
        {
            var jobBatch = await _context.JobBatches.FindAsync(id);
            if (jobBatch == null)
            {
                return NotFound();
            }

            _context.JobBatches.Remove(jobBatch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobBatchExists(string id)
        {
            return _context.JobBatches.Any(e => e.Id == id);
        }
    }
}
