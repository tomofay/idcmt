namespace Indocement_RESTFullAPI.DTOs;

public class UserDTO
{
    public decimal Id { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public EmployeeDTO? Employee { get; set; }
}