using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("cache", Schema = "indocement")]
public partial class Cache
{
    [Key]
    [Column("key")]
    [StringLength(255)]
    public string Key { get; set; } = null!;

    [Column("value")]
    public string Value { get; set; } = null!;

    [Column("expiration")]
    public int Expiration { get; set; }
}
