using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("cache_locks", Schema = "indocement")]
public partial class CacheLock
{
    [Key]
    [Column("key")]
    [StringLength(255)]
    public string Key { get; set; } = null!;

    [Column("owner")]
    [StringLength(255)]
    public string Owner { get; set; } = null!;

    [Column("expiration")]
    public int Expiration { get; set; }
}
