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

[Table("chat_room")]
public partial class ChatRoom: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("lang_id")]
    public Guid? LangId { get; set; }

    [Column("participant_count")]
    public long? ParticipantCount { get; set; }

    [Column("max_participant_reached")]
    public long? MaxParticipantReached { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("max_capacity")]
    public string? MaxCapacity { get; set; }

    [Column("last_activity", TypeName = "timestamp without time zone")]
    public DateTime? LastActivity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChatRoomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChatRoom")] // One2many
    public virtual ICollection<EventMeetingRoom> EventMeetingRoom { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ChatRoomId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChatRoom")] // One2many
    public virtual ICollection<EventSponsor> EventSponsor { get; set; }

    // [Many2one]
    [ForeignKey("LangId")]
    public virtual ResLang? Lang { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
