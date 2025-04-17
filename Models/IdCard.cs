using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("id_card", Schema = "indocement")]
[Index("IdEmployee", Name = "id_card_id_employee_foreign")]
public partial class IdCard
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_employee", TypeName = "numeric(20, 0)")]
    public decimal IdEmployee { get; set; }

    [Column("tgl_pengajuan")]
    [Precision(0)]
    public DateTime TglPengajuan { get; set; }

    [Column("status_pengajuan")]
    [StringLength(6)]
    public string StatusPengajuan { get; set; } = null!;

    [Column("url_card_rusak")]
    [StringLength(255)]
    public string? UrlCardRusak { get; set; }

    [Column("url_surat_kehilangan")]
    [StringLength(255)]
    public string? UrlSuratKehilangan { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("IdEmployee")]
    [InverseProperty("IdCards")]
    public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}
