namespace Indocement_RESTFullAPI.DTOs
{
    public class UserUpdateDTO
    {
        public string? EmployeeName { get; set; }
        public string? Email { get; set; }
        public string? Telepon { get; set; }
        public string? Password { get; set; }
        public string? LivingArea { get; set; } // Menambahkan LivingArea
    }
}
