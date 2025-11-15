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

[Table("event_registration")]
//[Index("UtmCampaignId", Name = "event_registration__utm_campaign_id_index")]
//[Index("UtmMediumId", Name = "event_registration__utm_medium_id_index")]
//[Index("UtmSourceId", Name = "event_registration__utm_source_id_index")]
//[Index("Barcode", Name = "event_registration_barcode_event_uniq", IsUnique = true)]
public partial class EventRegistration : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [JsonField] // RegistrationProperties
    [Column("registration_properties", TypeName = "jsonb")]
    public JsonElement? RegistrationProperties { get; set; }

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

    [Column("pos_order_line_id")]
    public Guid? PosOrderLineId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("sale_status")]
    public string? SaleStatus { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventId")]
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LastRegistrationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LastRegistration")] // One2many
    public virtual ICollection<EventMail> EventMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RegistrationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Registration")] // One2many
    public virtual ICollection<EventMailRegistration> EventMailRegistration { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RegistrationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Registration")] // One2many
    public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventTicketId")]
    public virtual EventEventTicket? EventTicket { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PosOrderLineId")]
    public virtual PosOrderLine? PosOrderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RegistrationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Registration")] // One2many
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderId")]
    public virtual SaleOrder? SaleOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderLineId")]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UtmCampaignId")]
    public virtual UtmCampaign? UtmCampaign { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UtmMediumId")]
    public virtual UtmMedium? UtmMedium { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UtmSourceId")]
    public virtual UtmSource? UtmSource { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VisitorId")]
    public virtual WebsiteVisitor? Visitor { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("EventRegistrationId")] //Many2many // Hidden
    // [InverseProperty("EventRegistration")] //Many2many // Hidden
    public virtual ICollection<CrmLead> CrmLead { get; set; }
}
