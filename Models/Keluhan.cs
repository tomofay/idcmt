using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("keluhan", Schema = "indocement")]
[Index("IdEmployee", Name = "keluhan_id_employee_foreign")]
public partial class Keluhan
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_employee", TypeName = "numeric(20, 0)")]
    public decimal IdEmployee { get; set; }

    [Column("tgl_keluhan")]
    [Precision(0)]
    public DateTime TglKeluhan { get; set; }

    [Column("keluhan")]
    public string? Keluhan1 { get; set; }

    [Column("status")]
    [StringLength(8)]
    public string Status { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("IdEmployee")]
    [InverseProperty("Keluhans")]
    public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}
