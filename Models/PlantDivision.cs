using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("plant_division", Schema = "indocement")]
[Index("NamaPlantDivision", Name = "plant_division$plant_division_nama_plant_division_unique", IsUnique = true)]
[Index("IdUnit", Name = "plant_division_id_unit_foreign")]
public partial class PlantDivision
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_unit", TypeName = "numeric(20, 0)")]
    public decimal IdUnit { get; set; }

    [Column("nama_plant_division")]
    [StringLength(255)]
    public string NamaPlantDivision { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("IdPlantDivisionNavigation")]
    public virtual ICollection<Departement> Departements { get; set; } = new List<Departement>();

    [ForeignKey("IdUnit")]
    [InverseProperty("PlantDivisions")]
    public virtual Unit? IdUnitNavigation { get; set; }
}
