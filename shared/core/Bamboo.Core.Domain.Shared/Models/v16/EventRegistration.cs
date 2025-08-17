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

[Table("event_registration")]
//[Index("UtmCampaignId", Name = "event_registration_utm_campaign_id_index")]
//[Index("UtmMediumId", Name = "event_registration_utm_medium_id_index")]
//[Index("UtmSourceId", Name = "event_registration_utm_source_id_index")]
public partial class EventRegistration: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("date_closed", TypeName = "timestamp without time zone")]
    public DateTime? DateClosed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("visitor_id")]
    public Guid? VisitorId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("is_paid")]
    public bool? IsPaid { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventRegistrationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [ForeignKey("RegistrationId")]
    [InverseProperty("Registration")]
    public virtual ICollection<EventMailRegistration> EventMailRegistration { get; set; }

    // [One2many]
    [ForeignKey("RegistrationId")]
    [InverseProperty("Registration")]
    public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswer { get; set; }

    // [Many2one]
    [ForeignKey("EventTicketId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual EventEventTicket? EventTicket { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [One2many]
    [ForeignKey("RegistrationId")]
    [InverseProperty("Registration")]
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLine { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual SaleOrder? SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("UtmCampaignId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual UtmCampaign? UtmCampaign { get; set; }

    // [Many2one]
    [ForeignKey("UtmMediumId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual UtmMedium? UtmMedium { get; set; }

    // [Many2one]
    [ForeignKey("UtmSourceId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual UtmSource? UtmSource { get; set; }

    // [Many2one]
    [ForeignKey("VisitorId")]
    // [InverseProperty("EventRegistration")] //Many2one
    public virtual WebsiteVisitor? Visitor { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventRegistrationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("EventRegistrationId")] //Many2many
    // [InverseProperty("EventRegistration")] //Many2many
    public virtual ICollection<CrmLead> CrmLead { get; set; }
}
