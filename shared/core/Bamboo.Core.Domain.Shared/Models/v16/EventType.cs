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

[Table("event_type")]
public partial class EventType: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("seats_max")]
    public long? SeatsMax { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("default_timezone")]
    public string? DefaultTimezone { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("ticket_instructions", TypeName = "jsonb")]
    public string? TicketInstructions { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("has_seats_limitation")]
    public bool? HasSeatsLimitation { get; set; }

    [Column("auto_confirm")]
    public bool? AutoConfirm { get; set; }

    [Column("menu_register_cta")]
    public bool? MenuRegisterCta { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_menu")]
    public bool? WebsiteMenu { get; set; }

    [Column("community_menu")]
    public bool? CommunityMenu { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("EventType")]
    [NotMapped]
    public virtual ICollection<EventEventTicket> EventEventTickets { get; set; } = new List<EventEventTicket>();

    //[InverseProperty("EventType")]
    [NotMapped]
    public virtual ICollection<EventEvent> EventEvents { get; set; } = new List<EventEvent>();

    //[InverseProperty("EventType")]
    [NotMapped]
    public virtual ICollection<EventQuestion> EventQuestions { get; set; } = new List<EventQuestion>();

    //[InverseProperty("EventType")]
    [NotMapped]
    public virtual ICollection<EventTypeMail> EventTypeMails { get; set; } = new List<EventTypeMail>();

    //[InverseProperty("EventType")]
    [NotMapped]
    public virtual ICollection<EventTypeTicket> EventTypeTickets { get; set; } = new List<EventTypeTicket>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventTypes")]
    [NotMapped]
    public virtual ICollection<EventLeadRule> EventLeadRules { get; set; } = new List<EventLeadRule>();

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventTypes")]
    [NotMapped]
    public virtual ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
}
