using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class ResDevice: Entity<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("session_identifier", TypeName = "character varying")]
    public string? SessionIdentifier { get; set; }

    [Column("platform", TypeName = "character varying")]
    public string? Platform { get; set; }

    [Column("browser", TypeName = "character varying")]
    public string? Browser { get; set; }

    [Column("ip_address", TypeName = "character varying")]
    public string? IpAddress { get; set; }

    [Column("country", TypeName = "character varying")]
    public string? Country { get; set; }

    [Column("city", TypeName = "character varying")]
    public string? City { get; set; }

    [Column("device_type", TypeName = "character varying")]
    public string? DeviceType { get; set; }

    [Column("revoked")]
    public bool? Revoked { get; set; }

    [Column("first_activity", TypeName = "timestamp without time zone")]
    public DateTime? FirstActivity { get; set; }

    [Column("last_activity", TypeName = "timestamp without time zone")]
    public DateTime? LastActivity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? DateTime { get; set; }
}
