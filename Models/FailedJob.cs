using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("failed_jobs", Schema = "indocement")]
[Index("Uuid", Name = "failed_jobs$failed_jobs_uuid_unique", IsUnique = true)]
public partial class FailedJob
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("uuid")]
    [StringLength(255)]
    public string Uuid { get; set; } = null!;

    [Column("connection")]
    public string Connection { get; set; } = null!;

    [Column("queue")]
    public string Queue { get; set; } = null!;

    [Column("payload")]
    public string Payload { get; set; } = null!;

    [Column("exception")]
    public string Exception { get; set; } = null!;

    [Column("failed_at", TypeName = "datetime")]
    public DateTime FailedAt { get; set; }
}
