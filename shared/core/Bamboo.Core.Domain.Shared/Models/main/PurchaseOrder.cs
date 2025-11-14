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

[Table("purchase_order")]
//[Index("CompanyId", Name = "purchase_order__company_id_index")]
//[Index("DateApprove", Name = "purchase_order__date_approve_index")]
//[Index("DateOrder", Name = "purchase_order__date_order_index")]
//[Index("DatePlanned", Name = "purchase_order__date_planned_index")]
//[Index("Priority", Name = "purchase_order__priority_index")]
//[Index("State", Name = "purchase_order__state_index")]
//[Index("UserId", Name = "purchase_order__user_id_index")]
public partial class PurchaseOrder: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

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

    [Column("amount_total_cc")]
    public decimal? AmountTotalCc { get; set; }

    [Column("currency_rate")]
    public decimal? CurrencyRate { get; set; }

    [Column("mail_reminder_confirmed")]
    public bool? MailReminderConfirmed { get; set; }

    [Column("mail_reception_confirmed")]
    public bool? MailReceptionConfirmed { get; set; }

    [Column("mail_reception_declined")]
    public bool? MailReceptionDeclined { get; set; }

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

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("requisition_id")]
    public Guid? RequisitionId { get; set; }

    [Column("purchase_group_id")]
    public Guid? PurchaseGroupId { get; set; }

    [Column("report_grids")]
    public bool? ReportGrids { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PurchaseOrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PurchaseOrder")] // One2many
    public virtual ICollection<BillToPoWizard> BillToPoWizard { get; set; }

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
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DestAddressId")]
    public virtual ResPartner? DestAddress { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("FiscalPositionId")]
    public virtual AccountFiscalPosition? FiscalPosition { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GroupId")]
    public virtual ProcurementGroup? Group { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IncotermId")]
    public virtual AccountIncoterms? Incoterm { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentTermId")]
    public virtual AccountPaymentTerm? PaymentTerm { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PickingTypeId")]
    public virtual StockPickingType? PickingType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PurchaseGroupId")]
    public virtual PurchaseOrderGroup? PurchaseGroup { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OrderId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Order")] // One2many
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OriginPoId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OriginPo")] // One2many
    public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternative { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RequisitionId")]
    public virtual PurchaseRequisition? Requisition { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PurchaseOrderId")] // Many2many // Normal
    // [InverseProperty("PurchaseOrder")] // Many2many // Normal
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PurchaseOrderId")] //Many2many // Hidden
    // [InverseProperty("PurchaseOrder")] //Many2many // Hidden
    public virtual ICollection<PurchaseRequisitionAlternativeWarning> PurchaseRequisitionAlternativeWarning { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PurchaseOrderId")] //Many2many // Hidden
    // [InverseProperty("PurchaseOrderNavigation")] //Many2many // Hidden
    public virtual ICollection<PurchaseRequisitionAlternativeWarning> PurchaseRequisitionAlternativeWarningNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PurchaseOrderId")] // Many2many // Normal
    // [InverseProperty("PurchaseOrder")] // Many2many // Normal
    public virtual ICollection<StockPicking> StockPicking { get; set; }
}
