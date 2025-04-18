using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("bpjs", Schema = "indocement")]
[Index("IdEmployee", Name = "bpjs_id_employee_foreign")]
public partial class Bpjs
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_employee", TypeName = "numeric(20, 0)")]
    public decimal IdEmployee { get; set; }

    [Column("tgl_pengajuan")]
    [Precision(0)]
    public DateTime TglPengajuan { get; set; }

    [Column("anggota_bpjs")]
    [StringLength(11)]
    public string AnggotaBpjs { get; set; } = null!;

    [Column("anak_ke")]
    [StringLength(255)]
    public string? AnakKe { get; set; }

    [Column("url_kk")]
    [StringLength(255)]
    public string? UrlKk { get; set; }

    [Column("url_surat_nikah")]
    [StringLength(255)]
    public string? UrlSuratNikah { get; set; }

    [Column("url_akte_lahir")]
    [StringLength(255)]
    public string? UrlAkteLahir { get; set; }

    [Column("url_surat_potong_gaji")]
    [StringLength(255)]
    public string? UrlSuratPotongGaji { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("IdEmployee")]
    [InverseProperty("Bpjs")]
    public virtual Employee? IdEmployeeNavigation { get; set; } // Jadikan nullable
}
