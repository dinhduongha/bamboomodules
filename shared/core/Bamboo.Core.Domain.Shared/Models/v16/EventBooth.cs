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

[Table("event_booth")]
public partial class EventBooth: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("booth_category_id")]
    public Guid? BoothCategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("contact_name")]
    public string? ContactName { get; set; }

    [Column("contact_email")]
    public string? ContactEmail { get; set; }

    [Column("contact_mobile")]
    public string? ContactMobile { get; set; }

    [Column("contact_phone")]
    public string? ContactPhone { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("is_paid")]
    public bool? IsPaid { get; set; }

    [Column("sponsor_id")]
    public Guid? SponsorId { get; set; }

    // [Many2one]
    [ForeignKey("BoothCategoryId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual EventBoothCategory? BoothCategory { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventBoothCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [ForeignKey("EventBoothId")]
    [InverseProperty("EventBooth")]
    public virtual ICollection<EventBoothRegistration> EventBoothRegistration { get; set; }

    // [Many2one]
    [ForeignKey("EventTypeId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual EventType? EventType { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual SaleOrder? SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SponsorId")]
    // [InverseProperty("EventBooth")] //Many2one
    public virtual EventSponsor? Sponsor { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventBoothWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("EventBoothId")]
    // [InverseProperty("EventBooth")]
    // public virtual ICollection<EventBoothConfigurator> EventBoothConfigurator { get; set; }
}
