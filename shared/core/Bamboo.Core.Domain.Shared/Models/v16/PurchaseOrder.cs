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

[Table("purchase_order")]
//[Index("CompanyId", Name = "purchase_order_company_id_index")]
//[Index("DateApprove", Name = "purchase_order_date_approve_index")]
//[Index("DateOrder", Name = "purchase_order_date_order_index")]
//[Index("DatePlanned", Name = "purchase_order_date_planned_index")]
//[Index("Priority", Name = "purchase_order_priority_index")]
//[Index("State", Name = "purchase_order_state_index")]
//[Index("UserId", Name = "purchase_order_user_id_index")]
public partial class PurchaseOrder: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("dest_address_id")]
    public Guid? DestAddressId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("invoice_count")]
    public long? InvoiceCount { get; set; }

    [Column("fiscal_position_id")]
    public Guid? FiscalPositionId { get; set; }

    [Column("payment_term_id")]
    public Guid? PaymentTermId { get; set; }

    [Column("incoterm_id")]
    public Guid? IncotermId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("origin")]
    public string? Origin { get; set; }

    [Column("partner_ref")]
    public string? PartnerRef { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("invoice_status")]
    public string? InvoiceStatus { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("amount_untaxed")]
    public decimal? AmountUntaxed { get; set; }

    [Column("amount_tax")]
    public decimal? AmountTax { get; set; }

    [Column("amount_total")]
    public decimal? AmountTotal { get; set; }

    [Column("mail_reminder_confirmed")]
    public bool? MailReminderConfirmed { get; set; }

    [Column("mail_reception_confirmed")]
    public bool? MailReceptionConfirmed { get; set; }

    [Column("date_order", TypeName = "timestamp without time zone")]
    public DateTime? DateOrder { get; set; }

    [Column("date_approve", TypeName = "timestamp without time zone")]
    public DateTime? DateApprove { get; set; }

    [Column("date_planned", TypeName = "timestamp without time zone")]
    public DateTime? DatePlanned { get; set; }

    [Column("date_calendar_start", TypeName = "timestamp without time zone")]
    public DateTime? DateCalendarStart { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("currency_rate")]
    public double? CurrencyRate { get; set; }

    [Column("picking_type_id")]
    public Guid? PickingTypeId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("incoterm_location")]
    public string? IncotermLocation { get; set; }

    [Column("receipt_status")]
    public string? ReceiptStatus { get; set; }

    [Column("effective_date", TypeName = "timestamp without time zone")]
    public DateTime? EffectiveDate { get; set; }

    [Column("requisition_id")]
    public Guid? RequisitionId { get; set; }

    [Column("purchase_group_id")]
    public Guid? PurchaseGroupId { get; set; }

    [Column("report_grids")]
    public bool? ReportGrids { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PurchaseOrderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DestAddressId")]
    // [InverseProperty("PurchaseOrderDestAddress")] //Many2one
    public virtual ResPartner? DestAddress { get; set; }

    // [Many2one]
    [ForeignKey("FiscalPositionId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual ProcurementGroup? Group { get; set; }

    // [Many2one]
    [ForeignKey("IncotermId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual AccountIncoterms? Incoterm { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("PurchaseOrderPartner")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PaymentTermId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual AccountPaymentTerm? PaymentTerm { get; set; }

    // [Many2one]
    [ForeignKey("PickingTypeId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [ForeignKey("PurchaseGroupId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual PurchaseOrderGroup? PurchaseGroup { get; set; }

    // [One2many]
    [ForeignKey("OrderId")]
    [InverseProperty("Order")]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    [ForeignKey("OriginPoId")]
    [InverseProperty("OriginPo")]
    public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternative { get; set; }

    // [Many2one]
    [ForeignKey("RequisitionId")]
    // [InverseProperty("PurchaseOrder")] //Many2one
    public virtual PurchaseRequisition? Requisition { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("PurchaseOrderUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PurchaseOrderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PurchaseOrderId")] //Many2many
    // [InverseProperty("PurchaseOrder")] //Many2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PurchaseOrderId")]
    // [InverseProperty("PurchaseOrder")]
    // public virtual ICollection<PurchaseRequisitionAlternativeWarning> PurchaseRequisitionAlternativeWarning { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PurchaseOrderId")]
    // [InverseProperty("PurchaseOrderNavigation")]
    // public virtual ICollection<PurchaseRequisitionAlternativeWarning> PurchaseRequisitionAlternativeWarningNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PurchaseOrderId")] //Many2many
    // [InverseProperty("PurchaseOrder")] //Many2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }
}
