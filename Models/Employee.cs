using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("employee", Schema = "indocement")]
[Index("Email", Name = "employee$employee_email_unique", IsUnique = true)]
[Index("EmployeeNo", Name = "employee$employee_employee_no_unique", IsUnique = true)]
[Index("IdEsl", Name = "employee_id_esl_foreign")]
[Index("IdSection", Name = "employee_id_section_foreign")]
public partial class Employee
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("employee_no")]
    [StringLength(7)]
    public string EmployeeNo { get; set; } = null!;

    [Column("employee_name")]
    [StringLength(100)]
    public string EmployeeName { get; set; } = null!;

    [Column("job_title")]
    [StringLength(255)]
    public string JobTitle { get; set; } = "Employee"; // Default job title bisa disesuaikan

    [Column("service_date")]
    public DateOnly ServiceDate { get; set; } = DateOnly.FromDateTime(DateTime.Now); // Default ke tanggal hari ini

    [Column("birth_date")]
    public DateOnly BirthDate { get; set; }

    [Column("no_bpjs")]
    [StringLength(255)]
    public string? NoBpjs { get; set; }

    [Column("gender")]
    [StringLength(1)]
    public string Gender { get; set; } = "M"; // Default gender 'M' (Male), bisa disesuaikan

    [Column("telepon")]
    [StringLength(15)]
    public string Telepon { get; set; } = null!;

    [Column("living_area")]
    [StringLength(255)]
    public string LivingArea { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("education")]
    [StringLength(14)]
    public string Education { get; set; } = "S1"; // Default education level bisa disesuaikan

    [Column("work_location")]
    [StringLength(255)]
    public string WorkLocation { get; set; } = "Headquarters"; // Default work location bisa disesuaikan

    [Column("id_section", TypeName = "numeric(20, 0)")]
    public decimal? IdSection { get; set; }

    [Column("id_esl", TypeName = "numeric(20, 0)")]
    public decimal? IdEsl { get; set; }

    [Column("url_foto")]
    [StringLength(255)]
    public string? UrlFoto { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    [InverseProperty("IdEmployeeNavigation")]
    public virtual ICollection<Bpjs> Bpjs { get; set; } = new List<Bpjs>();

    [InverseProperty("IdEmployeeNavigation")]
    public virtual ICollection<FamilyEmployee> FamilyEmployees { get; set; } = new List<FamilyEmployee>();

    [InverseProperty("IdEmployeeNavigation")]
    public virtual ICollection<IdCard> IdCards { get; set; } = new List<IdCard>();

    [ForeignKey("IdEsl")]
    [InverseProperty("Employees")]
    public virtual Esl? IdEslNavigation { get; set; }

    [ForeignKey("IdSection")]
    [InverseProperty("Employees")]
    public virtual Section? IdSectionNavigation { get; set; }

    [InverseProperty("IdEmployeeNavigation")]
    public virtual ICollection<Keluhan> Keluhans { get; set; } = new List<Keluhan>();

    [InverseProperty("IdEmployeeNavigation")]
    public virtual ICollection<Konsultasi> Konsultasis { get; set; } = new List<Konsultasi>();

    [InverseProperty("IdEmployeeNavigation")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
