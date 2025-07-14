using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("event_registration")]
//[Index("UtmCampaignId", Name = "event_registration__utm_campaign_id_index")]
//[Index("UtmMediumId", Name = "event_registration__utm_medium_id_index")]
//[Index("UtmSourceId", Name = "event_registration__utm_source_id_index")]
//[Index("Barcode", Name = "event_registration_barcode_event_uniq", IsUnique = true)]
public partial class EventRegistration: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("event_ticket_id")]
    public Guid? EventTicketId { get; set; }

    [Column("utm_campaign_id")]
    public Guid? UtmCampaignId { get; set; }

    [Column("utm_source_id")]
    public Guid? UtmSourceId { get; set; }

    [Column("utm_medium_id")]
    public Guid? UtmMediumId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("company_name")]
    public string? CompanyName { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("registration_properties", TypeName = "jsonb")]
    public string? RegistrationProperties { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("visitor_id")]
    public Guid? VisitorId { get; set; }

    [Column("pos_order_line_id")]
    public Guid? PosOrderLineId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("sale_status")]
    public string? SaleStatus { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventRegistrationCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    //[InverseProperty("Registration")]
    [NotMapped]
    public virtual ICollection<EventMailRegistration> EventMailRegistrations { get; set; } = new List<EventMailRegistration>();

    //[InverseProperty("LastRegistration")]
    [NotMapped]
    public virtual ICollection<EventMail> EventMails { get; set; } = new List<EventMail>();

    //[InverseProperty("Registration")]
    [NotMapped]
    public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswers { get; set; } = new List<EventRegistrationAnswer>();

    [ForeignKey("EventTicketId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual EventEventTicket? EventTicket { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PosOrderLineId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual PosOrderLine? PosOrderLine { get; set; }

    //[InverseProperty("Registration")]
    [NotMapped]
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLines { get; set; } = new List<RegistrationEditorLine>();

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual SaleOrder? SaleOrder { get; set; }

    [ForeignKey("SaleOrderLineId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    [ForeignKey("UtmCampaignId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual UtmCampaign? UtmCampaign { get; set; }

    [ForeignKey("UtmMediumId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual UtmMedium? UtmMedium { get; set; }

    [ForeignKey("UtmSourceId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual UtmSource? UtmSource { get; set; }

    [ForeignKey("VisitorId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual WebsiteVisitor? Visitor { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventRegistrationWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("EventRegistrationId")]
    //[InverseProperty("EventRegistrations")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();
}
