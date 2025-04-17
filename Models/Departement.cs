using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("departement", Schema = "indocement")]
[Index("NamaDepartement", Name = "departement$departement_nama_departement_unique", IsUnique = true)]
[Index("IdPlantDivision", Name = "departement_id_plant_division_foreign")]
public partial class Departement
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_plant_division", TypeName = "numeric(20, 0)")]
    public decimal IdPlantDivision { get; set; }

    [Column("nama_departement")]
    [StringLength(255)]
    public string NamaDepartement { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("IdPlantDivision")]
    [InverseProperty("Departements")]
    public virtual PlantDivision? IdPlantDivisionNavigation { get; set; }

    [InverseProperty("IdDepartementNavigation")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
