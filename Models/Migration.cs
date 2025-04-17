using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("migrations", Schema = "indocement")]
public partial class Migration
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("migration")]
    [StringLength(255)]
    public string Migration1 { get; set; } = null!;

    [Column("batch")]
    public int Batch { get; set; }
}
