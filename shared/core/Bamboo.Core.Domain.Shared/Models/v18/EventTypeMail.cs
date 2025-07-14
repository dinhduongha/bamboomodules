using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("event_type_mail")]
public partial class EventTypeMail: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("interval_nbr")]
    public long? IntervalNbr { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("interval_unit")]
    public string? IntervalUnit { get; set; }

    [Column("interval_type")]
    public string? IntervalType { get; set; }

    [Column("template_ref")]
    public string? TemplateRef { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventTypeMailCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventTypeMails")]
    [NotMapped]
    public virtual EventType? EventType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventTypeMailWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
