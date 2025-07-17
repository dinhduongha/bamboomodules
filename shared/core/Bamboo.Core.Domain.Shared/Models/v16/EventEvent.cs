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

[Table("event_event")]
//[Index("IsPublished", Name = "event_event__is_published_index")]
//[Index("WebsiteId", Name = "event_event__website_id_index")]
public partial class EventEvent: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("registration_properties_definition", TypeName = "jsonb")]
    public string? RegistrationPropertiesDefinition { get; set; }

    [Column("ticket_instructions", TypeName = "jsonb")]
    public string? TicketInstructions { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("seats_limited")]
    public bool? SeatsLimited { get; set; }

    [Column("auto_confirm")]
    public bool? AutoConfirm { get; set; }

    [Column("date_begin", TypeName = "timestamp without time zone")]
    public DateTime? DateBegin { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("menu_id")]
    public Guid? MenuId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("website_visibility")]
    public string? WebsiteVisibility { get; set; }

    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [Column("subtitle", TypeName = "jsonb")]
    public string? Subtitle { get; set; }

    [Column("cover_properties")]
    public string? CoverProperties { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("website_menu")]
    public bool? WebsiteMenu { get; set; }

    [Column("menu_register_cta")]
    public bool? MenuRegisterCta { get; set; }

    [Column("introduction_menu")]
    public bool? IntroductionMenu { get; set; }

    [Column("location_menu")]
    public bool? LocationMenu { get; set; }

    [Column("register_menu")]
    public bool? RegisterMenu { get; set; }

    [Column("community_menu")]
    public bool? CommunityMenu { get; set; }

    [ForeignKey("AddressId")]
    //[InverseProperty("EventEventAddresses")]
    [NotMapped]
    public virtual ResPartner? Address { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventEventCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAccounts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
    
    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<EventEventConfigurator> EventEventConfigurators { get; set; } = new List<EventEventConfigurator>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<EventEventTicket> EventEventTickets { get; set; } = new List<EventEventTicket>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual EventLeadRequest? EventLeadRequest { get; set; }

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<EventLeadRule> EventLeadRules { get; set; } = new List<EventLeadRule>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<EventMail> EventMails { get; set; } = new List<EventMail>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<EventQuestion> EventQuestions { get; set; } = new List<EventQuestion>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual EventType? EventType { get; set; }

    [ForeignKey("MenuId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual WebsiteMenu? Menu { get; set; }

    [ForeignKey("OrganizerId")]
    //[InverseProperty("EventEventOrganizers")]
    [NotMapped]
    public virtual ResPartner? Organizer { get; set; }

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLines { get; set; } = new List<RegistrationEditorLine>();

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    [ForeignKey("StageId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual EventStage? Stage { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("EventEventUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    //[InverseProperty("Event")]
    [NotMapped]
    public virtual ICollection<WebsiteEventMenu> WebsiteEventMenus { get; set; } = new List<WebsiteEventMenu>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventEventWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("EventEventId")]
    //[InverseProperty("EventEvents")]
    [NotMapped]
    public virtual ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
}
