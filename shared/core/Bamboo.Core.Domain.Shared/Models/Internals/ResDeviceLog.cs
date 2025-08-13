using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
[Table("res_device_log")]
//[Index("LastActivity", Name = "res_device_log__last_activity_index")]
//[Index("SessionIdentifier", Name = "res_device_log__session_identifier_index")]
//[Index("UserId", Name = "res_device_log__user_id_index")]
public partial class ResDeviceLog: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("session_identifier")]
    public string? SessionIdentifier { get; set; }

    [Column("platform")]
    public string? Platform { get; set; }

    [Column("browser")]
    public string? Browser { get; set; }

    [Column("ip_address")]
    public string? IpAddress { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("device_type")]
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
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResDeviceLogCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ResDeviceLogUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResDeviceLogWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
