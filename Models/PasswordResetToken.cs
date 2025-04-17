using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Indocement_RESTFullAPI.Models;

[Table("password_reset_tokens", Schema = "indocement")]
public partial class PasswordResetToken
{
    [Key]
    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("token")]
    [StringLength(255)]
    public string Token { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
