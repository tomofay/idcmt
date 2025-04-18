using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("users", Schema = "indocement")]
[Index("Email", Name = "users$users_email_unique", IsUnique = true)]
[Index("IdEmployee", Name = "users_id_employee_foreign")]
public partial class User
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_employee", TypeName = "numeric(20, 0)")]
    public decimal IdEmployee { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("email_verified_at", TypeName = "datetime")]
    public DateTime? EmailVerifiedAt { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string Password { get; set; } = null!;

    [Column("remember_token")]
    [StringLength(100)]
    public string? RememberToken { get; set; }

    [Column("role")]
    [StringLength(8)]
    public string JobTitle { get; set; } = "Employee";  // Default job title

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    // Relasi ke Employee
    [ForeignKey("IdEmployee")]
    [InverseProperty("Users")]
    public virtual Employee? IdEmployeeNavigation { get; set; }
}
