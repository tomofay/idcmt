using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("jobs", Schema = "indocement")]
[Index("Queue", Name = "jobs_queue_index")]
public partial class Job
{
    [Key]
    [Column("id", TypeName = "numeric(20, 0)")]
    public decimal Id { get; set; }

    [Column("queue")]
    [StringLength(255)]
    public string Queue { get; set; } = null!;

    [Column("payload")]
    public string Payload { get; set; } = null!;

    [Column("attempts")]
    public byte Attempts { get; set; }

    [Column("reserved_at")]
    public long? ReservedAt { get; set; }

    [Column("available_at")]
    public long AvailableAt { get; set; }

    [Column("created_at")]
    public long CreatedAt { get; set; }
}
