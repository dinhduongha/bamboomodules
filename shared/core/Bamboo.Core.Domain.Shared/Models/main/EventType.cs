using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("event_type")]
public partial class EventType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("seats_max")]
    public long? SeatsMax { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("default_timezone")]
    public string? DefaultTimezone { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField] // TicketInstructions
    [Column("ticket_instructions", TypeName = "jsonb")]
    public JsonElement? TicketInstructions { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("has_seats_limitation")]
    public bool? HasSeatsLimitation { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_menu")]
    public bool? WebsiteMenu { get; set; }

    [Column("community_menu")]
    public bool? CommunityMenu { get; set; }

    [Column("booth_menu")]
    public bool? BoothMenu { get; set; }

    [Column("exhibitor_menu")]
    public bool? ExhibitorMenu { get; set; }

    [Column("meeting_room_allow_creation")]
    public bool? MeetingRoomAllowCreation { get; set; }

    [Column("website_track")]
    public bool? WebsiteTrack { get; set; }

    [Column("website_track_proposal")]
    public bool? WebsiteTrackProposal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventEventTicket> EventEventTicket { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventQuestion> EventQuestion { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventTypeBooth> EventTypeBooth { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventTypeMail> EventTypeMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EventType")] // One2many
    public virtual ICollection<EventTypeTicket> EventTypeTicket { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("EventTypeId")] //Many2many // Hidden
    // [InverseProperty("EventType")] //Many2many // Hidden
    public virtual ICollection<EventLeadRule> EventLeadRule { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventTypeId")] // Many2many // Normal
    // [InverseProperty("EventType")] // Many2many // Normal
    public virtual ICollection<EventTag> EventTag { get; set; }
}
