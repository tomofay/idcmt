using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indocement_RESTFullAPI.Models;
using Indocement_RESTFullAPI.DTOs;
using System.Threading.Tasks;

namespace Indocement_RESTFullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IndocementDbContext _context;

        public UserController(IndocementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            if (userRegisterDTO == null)
                return BadRequest("Invalid data.");

            // Cek apakah email sudah terdaftar
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userRegisterDTO.Email);
            if (existingUser != null)
                return Conflict("Email is already registered.");

            // Cari employee berdasarkan EmployeeNo
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeNo == userRegisterDTO.EmployeeNo);

            // Kalau belum ada, buat baru
            if (employee == null)
            {
                employee = new Employee
                {
                    EmployeeNo = userRegisterDTO.EmployeeNo,
                    EmployeeName = userRegisterDTO.EmployeeName,
                    Telepon = userRegisterDTO.Telepon,
                    Email = userRegisterDTO.Email,
                    LivingArea = "Unknown" // Tambahkan nilai default untuk LivingArea
                };

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync(); // Save employee
            }

            // Menciptakan entitas user baru dari DTO
            var user = new User
            {
                Email = userRegisterDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password),
                Role = "Employee", // default role
                IdEmployee = employee.Id, // Menyambungkan employee dengan user
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // Save user

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, new
            {
                user.Id,
                user.Email,
                user.Role
            });
        }


        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            if (userLoginDTO == null)
                return BadRequest("Invalid data.");

            var user = await _context.Users.Include(u => u.IdEmployeeNavigation)
                                           .FirstOrDefaultAsync(u => u.Email == userLoginDTO.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, user.Password))
                return Unauthorized("Invalid credentials.");

            // Update kode login dan get user supaya memeriksa null dengan null conditional operator
            return Ok(new
            {
                user.Id,
                user.Email,
                user.Role,
                EmployeeName = user.IdEmployeeNavigation?.EmployeeName ?? "Unknown", // Default ke "Unknown" jika null
                Telepon = user.IdEmployeeNavigation?.Telepon ?? "Unknown" // Default ke "Unknown" jika null
            });

        }

        // Get user by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(decimal id)
        {
            var user = await _context.Users
                .Include(u => u.IdEmployeeNavigation)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound("User not found.");

            return Ok(new
            {
                user.Id,
                user.Email,
                user.Role,
                user.CreatedAt,
                user.UpdatedAt,
                Employee = user.IdEmployeeNavigation == null ? null : new
                {
                    user.IdEmployeeNavigation.Id,
                    user.IdEmployeeNavigation.EmployeeName,
                    user.IdEmployeeNavigation.Telepon,
                    user.IdEmployeeNavigation.LivingArea, // Menggunakan LivingArea sebagai alamat
                    user.IdEmployeeNavigation.JobTitle,
                    user.IdEmployeeNavigation.Gender,
                    user.IdEmployeeNavigation.CreatedAt,
                    user.IdEmployeeNavigation.UpdatedAt
                }
            });
        }



        // Update user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(decimal id, [FromBody] UserUpdateDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data.");

            var user = await _context.Users.Include(u => u.IdEmployeeNavigation)
                                           .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound("User not found.");

            // Update data user
            user.Email = dto.Email ?? user.Email;
            if (!string.IsNullOrEmpty(dto.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            user.UpdatedAt = DateTime.Now;

            // Update data employee
            if (user.IdEmployeeNavigation != null)
            {
                user.IdEmployeeNavigation.EmployeeName = dto.EmployeeName ?? user.IdEmployeeNavigation.EmployeeName;
                user.IdEmployeeNavigation.Telepon = dto.Telepon ?? user.IdEmployeeNavigation.Telepon;
                user.IdEmployeeNavigation.LivingArea = dto.LivingArea ?? user.IdEmployeeNavigation.LivingArea; // Update LivingArea
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                user.Id,
                user.Email,
                user.Role,
                EmployeeName = user.IdEmployeeNavigation?.EmployeeName,
                Telepon = user.IdEmployeeNavigation?.Telepon,
                LivingArea = user.IdEmployeeNavigation?.LivingArea // Menambahkan LivingArea dalam response
            });
        }



        // Delete user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(decimal id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound("User not found.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
