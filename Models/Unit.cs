using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("unit", Schema = "indocement")]
[Index("NamaUnit", Name = "unit$unit_nama_unit_unique", IsUnique = true)]
public partial class Unit
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("nama_unit")]
    [StringLength(100)]
    public string NamaUnit { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("IdUnitNavigation")]
    public virtual ICollection<PlantDivision> PlantDivisions { get; set; } = new List<PlantDivision>();
}
