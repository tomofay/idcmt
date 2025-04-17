namespace Indocement_RESTFullAPI.DTOs;

public class EmployeeDTO
{
    public decimal Id { get; set; }
    public string EmployeeNo { get; set; } = null!;
    public string EmployeeName { get; set; } = null!;
    public string Telepon { get; set; } = null!;
    public string LivingArea { get; set; } = null!;
    public string Email { get; set; } = null!;
}