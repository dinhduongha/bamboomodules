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

[Table("event_event")]
//[Index("IsPublished", Name = "event_event__is_published_index")]
//[Index("WebsiteId", Name = "event_event__website_id_index")]
public partial class EventEvent : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("organizer_id")]
    public Guid? OrganizerId { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("seats_max")]
    public long? SeatsMax { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [Column("kanban_state_label")]
    public string? KanbanStateLabel { get; set; }

    [Column("date_tz")]
    public string? DateTz { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("badge_format")]
    public string? BadgeFormat { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // Description
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [JsonField] // RegistrationPropertiesDefinition
    [Column("registration_properties_definition", TypeName = "jsonb")]
    public JsonElement? RegistrationPropertiesDefinition { get; set; }

    [JsonField] // TicketInstructions
    [Column("ticket_instructions", TypeName = "jsonb")]
    public JsonElement? TicketInstructions { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("seats_limited")]
    public bool? SeatsLimited { get; set; }

    [Column("date_begin", TypeName = "timestamp without time zone")]
    public DateTime? DateBegin { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("menu_id")]
    public Guid? MenuId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("website_visibility")]
    public string? WebsiteVisibility { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaTitle
    [Column("website_meta_title", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaTitle { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaDescription
    [Column("website_meta_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaDescription { get; set; }

    [JsonField] // WebsiteMetaKeywords
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public JsonElement? WebsiteMetaKeywords { get; set; }

    [JsonField(IsSparse = false)] // SeoName
    [Column("seo_name", TypeName = "jsonb")]
    public StringDictionary? SeoName { get; set; }

    [JsonField] // Subtitle
    [Column("subtitle", TypeName = "jsonb")]
    public JsonElement? Subtitle { get; set; }

    [Column("cover_properties")]
    public string? CoverProperties { get; set; }

    [Column("slug")]
    public string? Slug { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("website_menu")]
    public bool? WebsiteMenu { get; set; }

    [Column("introduction_menu")]
    public bool? IntroductionMenu { get; set; }

    [Column("location_menu")]
    public bool? LocationMenu { get; set; }

    [Column("register_menu")]
    public bool? RegisterMenu { get; set; }

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
    [ForeignKey("AddressId")]
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventBoothConfigurator> EventBoothConfigurator { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventEventConfigurator> EventEventConfigurator { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventEventTicket> EventEventTicket { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual EventLeadRequest? EventLeadRequest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventLeadRule> EventLeadRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventMail> EventMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventMeetingRoom> EventMeetingRoom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventQuestion> EventQuestion { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventQuiz> EventQuiz { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventSponsor> EventSponsor { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<EventTrack> EventTrack { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventTypeId")]
    public virtual EventType? EventType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MenuId")]
    public virtual WebsiteMenu? Menu { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrganizerId")]
    public virtual ResPartner? Organizer { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StageId")]
    public virtual EventStage? Stage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EventId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Event")] // One2many
    public virtual ICollection<WebsiteEventMenu> WebsiteEventMenu { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventEventId")] // Many2many // Normal
    // [InverseProperty("EventEvent")] // Many2many // Normal
    public virtual ICollection<EventTag> EventTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventEventId")] // Many2many // Normal
    // [InverseProperty("EventEvent")] // Many2many // Normal
    public virtual ICollection<EventTrackTag> EventTrackTag { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EventEventId")] // Many2many // Normal
    // [InverseProperty("EventEventNavigation")] // Many2many // Normal
    public virtual ICollection<EventTrackTag> EventTrackTagNavigation { get; set; }
}
