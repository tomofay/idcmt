using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Indocement_RESTFullAPI.Models;

namespace Indocement_RESTFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpjsController : ControllerBase
    {
        private readonly IndocementDbContext _context;
        private readonly ILogger<BpjsController> _logger;

        public BpjsController(IndocementDbContext context, ILogger<BpjsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Bpjs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bpjs>>> GetBpjs()
        {
            return await _context.Bpjs
                .Include(b => b.IdEmployeeNavigation) // Memuat properti navigasi
                .ToListAsync();
        }

        // GET: api/Bpjs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bpjs>> GetBpjs(decimal id)
        {
            var bpjs = await _context.Bpjs
                .Include(b => b.IdEmployeeNavigation) // Memuat properti navigasi
                .FirstOrDefaultAsync(b => b.Id == id);

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
            if (!_context.Employees.Any(e => e.Id == bpjs.IdEmployee))
            {
                return BadRequest(new { message = "Invalid IdEmployee." });
            }

            // Muat data Employee berdasarkan IdEmployee
            var employee = await _context.Employees.FindAsync(bpjs.IdEmployee);
            if (employee == null)
            {
                return BadRequest(new { message = "Employee not found." });
            }

            // Isi properti navigasi
            bpjs.IdEmployeeNavigation = employee;

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

        /// <summary>
        /// Upload a file and associate it with a BPJS record.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="idBpjs">The ID of the BPJS record.</param>
        /// <param name="fileType">The type of the file (e.g., UrlKk, UrlSuratNikah).</param>
        /// <returns>The URL of the uploaded file.</returns>
        // POST: api/Bpjs/upload
        [HttpPost("upload")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] decimal idBpjs, [FromForm] string fileType)
        {
            // Validasi fileType
            if (!new[] { "UrlKk", "UrlSuratNikah", "UrlAkteLahir", "UrlSuratPotongGaji" }.Contains(fileType))
            {
                return BadRequest(new { message = "Invalid file type." });
            }

            // Validasi file
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "File is not provided or empty." });
            }

            // Validasi ekstensi file
            var extension = Path.GetExtension(file.FileName).ToLower(); // Ekstensi file
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest(new { message = "Invalid file type. Only JPG, JPEG, PNG, and PDF are allowed." });
            }

            // Cek apakah BPJS dengan ID yang diberikan ada
            var bpjs = await _context.Bpjs.FindAsync(idBpjs);
            if (bpjs == null)
            {
                return NotFound(new { message = "BPJS record not found." });
            }

            // Tentukan lokasi penyimpanan file
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Tentukan prefix berdasarkan fileType
            string prefix = fileType switch
            {
                "UrlKk" => "kk",
                "UrlSuratNikah" => "surat_nikah",
                "UrlAkteLahir" => "akte_lahir",
                "UrlSuratPotongGaji" => "surat_potong_gaji",
                _ => "unknown"
            };

            // Buat nama file unik
            var randomNumber = new Random().Next(1000, 9999); // Nomor urut acak
            var uniqueFileName = $"{prefix}_{idBpjs}_{randomNumber}{extension}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Simpan file ke folder
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Simpan URL file ke kolom yang sesuai
            var fileUrl = $"/uploads/{uniqueFileName}";
            switch (fileType)
            {
                case "UrlKk":
                    bpjs.UrlKk = fileUrl;
                    break;
                case "UrlSuratNikah":
                    bpjs.UrlSuratNikah = fileUrl;
                    break;
                case "UrlAkteLahir":
                    bpjs.UrlAkteLahir = fileUrl;
                    break;
                case "UrlSuratPotongGaji":
                    bpjs.UrlSuratPotongGaji = fileUrl;
                    break;
            }

            // Log informasi file yang diunggah
            _logger.LogInformation($"File uploaded: {uniqueFileName}, BPJS ID: {idBpjs}, URL: {fileUrl}");

            // Perbarui database
            _context.Entry(bpjs).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "File uploaded successfully.",
                url = fileUrl,
                fileName = uniqueFileName,
                fileType = fileType
            });
        }

        private bool BpjsExists(decimal id)
        {
            return _context.Bpjs.Any(e => e.Id == id);
        }
    }
}
