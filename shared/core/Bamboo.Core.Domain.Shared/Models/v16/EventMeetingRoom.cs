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

[Table("event_meeting_room")]
//[Index("IsPublished", Name = "event_meeting_room__is_published_index")]
public partial class EventMeetingRoom: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("chat_room_id")]
    public Guid? ChatRoomId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("summary", TypeName = "jsonb")]
    public string? Summary { get; set; }

    [JsonField]
    [Column("target_audience", TypeName = "jsonb")]
    public string? TargetAudience { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_pinned")]
    public bool? IsPinned { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ChatRoomId")]
    // [InverseProperty("EventMeetingRoom")] //Many2one
    public virtual ChatRoom? ChatRoom { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventMeetingRoomCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("EventMeetingRoom")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventMeetingRoomWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
