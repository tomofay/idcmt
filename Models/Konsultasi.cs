using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("konsultasi", Schema = "indocement")]
[Index("IdEmployee", Name = "konsultasi_id_employee_foreign")]
public partial class Konsultasi
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_employee", TypeName = "numeric(20, 0)")]
    public decimal IdEmployee { get; set; }

    [Column("tgl_konsultasi")]
    [Precision(0)]
    public DateTime TglKonsultasi { get; set; }

    [Column("konsultasi")]
    public string? Konsultasi1 { get; set; }

    [Column("id_karyawan", TypeName = "numeric(20, 0)")]
    public decimal IdKaryawan { get; set; }

    [Column("status")]
    [StringLength(8)]
    public string Status { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("IdEmployee")]
    [InverseProperty("Konsultasis")]
    public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}
