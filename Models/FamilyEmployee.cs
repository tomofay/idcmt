using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("family_employee", Schema = "indocement")]
[Index("EmailAyahMertua", Name = "family_employee$family_employee_email_ayah_mertua_unique", IsUnique = true)]
[Index("EmailAyah", Name = "family_employee$family_employee_email_ayah_unique", IsUnique = true)]
[Index("EmailIbuMertua", Name = "family_employee$family_employee_email_ibu_mertua_unique", IsUnique = true)]
[Index("EmailIbu", Name = "family_employee$family_employee_email_ibu_unique", IsUnique = true)]
[Index("EmailPasangan", Name = "family_employee$family_employee_email_pasangan_unique", IsUnique = true)]
[Index("IdEmployee", Name = "family_employee_id_employee_foreign")]
public partial class FamilyEmployee
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("id_employee", TypeName = "numeric(20, 0)")]
    public decimal IdEmployee { get; set; }

    [Column("nama_pasangan")]
    [StringLength(255)]
    public string NamaPasangan { get; set; } = null!;

    [Column("status_pasangan")]
    [StringLength(5)]
    public string StatusPasangan { get; set; } = null!;

    [Column("jk_pasangan")]
    [StringLength(1)]
    public string JkPasangan { get; set; } = null!;

    [Column("tgl_lahir_pasangan")]
    public DateOnly TglLahirPasangan { get; set; }

    [Column("no_bpjs_pasangan")]
    [StringLength(255)]
    public string NoBpjsPasangan { get; set; } = null!;

    [Column("pendidikan_pasangan")]
    [StringLength(14)]
    public string PendidikanPasangan { get; set; } = null!;

    [Column("telepon_pasangan")]
    [StringLength(15)]
    public string? TeleponPasangan { get; set; }

    [Column("alamat_pasangan")]
    [StringLength(255)]
    public string? AlamatPasangan { get; set; }

    [Column("email_pasangan")]
    [StringLength(255)]
    public string EmailPasangan { get; set; } = null!;

    [Column("foto_pasangan")]
    [StringLength(255)]
    public string? FotoPasangan { get; set; }

    [Column("nama_anak")]
    public string NamaAnak { get; set; } = null!;

    [Column("tgl_lahir_anak")]
    public string TglLahirAnak { get; set; } = null!;

    [Column("status_anak")]
    public string StatusAnak { get; set; } = null!;

    [Column("jk_anak")]
    public string JkAnak { get; set; } = null!;

    [Column("no_bpjs_anak")]
    public string NoBpjsAnak { get; set; } = null!;

    [Column("pendidikan_anak")]
    public string PendidikanAnak { get; set; } = null!;

    [Column("foto_anak")]
    public string FotoAnak { get; set; } = null!;

    [Column("nama_ayah")]
    [StringLength(255)]
    public string NamaAyah { get; set; } = null!;

    [Column("status_ayah")]
    [StringLength(7)]
    public string StatusAyah { get; set; } = null!;

    [Column("jk_ayah")]
    [StringLength(1)]
    public string JkAyah { get; set; } = null!;

    [Column("no_bpjs_ayah")]
    [StringLength(255)]
    public string NoBpjsAyah { get; set; } = null!;

    [Column("tgl_lahir_ayah")]
    public DateOnly TglLahirAyah { get; set; }

    [Column("pendidikan_ayah")]
    [StringLength(14)]
    public string PendidikanAyah { get; set; } = null!;

    [Column("telepon_ayah")]
    [StringLength(15)]
    public string? TeleponAyah { get; set; }

    [Column("alamat_ayah")]
    [StringLength(255)]
    public string? AlamatAyah { get; set; }

    [Column("email_ayah")]
    [StringLength(255)]
    public string EmailAyah { get; set; } = null!;

    [Column("foto_ayah")]
    [StringLength(255)]
    public string? FotoAyah { get; set; }

    [Column("nama_ibu")]
    [StringLength(255)]
    public string NamaIbu { get; set; } = null!;

    [Column("status_ibu")]
    [StringLength(7)]
    public string StatusIbu { get; set; } = null!;

    [Column("jk_ibu")]
    [StringLength(1)]
    public string JkIbu { get; set; } = null!;

    [Column("no_bpjs_ibu")]
    [StringLength(255)]
    public string NoBpjsIbu { get; set; } = null!;

    [Column("tgl_lahir_ibu")]
    public DateOnly TglLahirIbu { get; set; }

    [Column("pendidikan_ibu")]
    [StringLength(14)]
    public string PendidikanIbu { get; set; } = null!;

    [Column("telepon_ibu")]
    [StringLength(15)]
    public string? TeleponIbu { get; set; }

    [Column("alamat_ibu")]
    [StringLength(255)]
    public string? AlamatIbu { get; set; }

    [Column("email_ibu")]
    [StringLength(255)]
    public string EmailIbu { get; set; } = null!;

    [Column("foto_ibu")]
    [StringLength(255)]
    public string? FotoIbu { get; set; }

    [Column("nama_ayah_mertua")]
    [StringLength(255)]
    public string NamaAyahMertua { get; set; } = null!;

    [Column("status_ayah_mertua")]
    [StringLength(7)]
    public string StatusAyahMertua { get; set; } = null!;

    [Column("jk_ayah_mertua")]
    [StringLength(1)]
    public string JkAyahMertua { get; set; } = null!;

    [Column("no_bpjs_ayah_mertua")]
    [StringLength(255)]
    public string NoBpjsAyahMertua { get; set; } = null!;

    [Column("tgl_lahir_ayah_mertua")]
    public DateOnly TglLahirAyahMertua { get; set; }

    [Column("pendidikan_ayah_mertua")]
    [StringLength(14)]
    public string PendidikanAyahMertua { get; set; } = null!;

    [Column("telepon_ayah_mertua")]
    [StringLength(15)]
    public string? TeleponAyahMertua { get; set; }

    [Column("alamat_ayah_mertua")]
    [StringLength(255)]
    public string? AlamatAyahMertua { get; set; }

    [Column("email_ayah_mertua")]
    [StringLength(255)]
    public string EmailAyahMertua { get; set; } = null!;

    [Column("foto_ayah_mertua")]
    [StringLength(255)]
    public string? FotoAyahMertua { get; set; }

    [Column("nama_ibu_mertua")]
    [StringLength(255)]
    public string NamaIbuMertua { get; set; } = null!;

    [Column("status_ibu_mertua")]
    [StringLength(7)]
    public string StatusIbuMertua { get; set; } = null!;

    [Column("jk_ibu_mertua")]
    [StringLength(1)]
    public string JkIbuMertua { get; set; } = null!;

    [Column("no_bpjs_ibu_mertua")]
    [StringLength(255)]
    public string NoBpjsIbuMertua { get; set; } = null!;

    [Column("tgl_lahir_ibu_mertua")]
    public DateOnly TglLahirIbuMertua { get; set; }

    [Column("pendidikan_ibu_mertua")]
    [StringLength(14)]
    public string PendidikanIbuMertua { get; set; } = null!;

    [Column("telepon_ibu_mertua")]
    [StringLength(15)]
    public string? TeleponIbuMertua { get; set; }

    [Column("alamat_ibu_mertua")]
    [StringLength(255)]
    public string? AlamatIbuMertua { get; set; }

    [Column("email_ibu_mertua")]
    [StringLength(255)]
    public string EmailIbuMertua { get; set; } = null!;

    [Column("foto_ibu_mertua")]
    [StringLength(255)]
    public string? FotoIbuMertua { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("IdEmployee")]
    [InverseProperty("FamilyEmployees")]
    public virtual Employee IdEmployeeNavigation { get; set; } = null!;
}
