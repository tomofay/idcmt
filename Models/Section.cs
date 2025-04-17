using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("section", Schema = "indocement")]
[Index("NamaSection", Name = "section$section_nama_section_unique", IsUnique = true)]
[Index("IdDepartement", Name = "section_id_departement_foreign")]
public partial class Section
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_departement", TypeName = "numeric(20, 0)")]
    public decimal IdDepartement { get; set; }

    [Column("nama_section")]
    [StringLength(255)]
    public string NamaSection { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("IdSectionNavigation")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("IdDepartement")]
    [InverseProperty("Sections")]
    public virtual Departement? IdDepartementNavigation { get; set; }
}
