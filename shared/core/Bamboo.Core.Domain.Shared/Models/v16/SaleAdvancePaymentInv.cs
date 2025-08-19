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

[Table("sale_advance_payment_inv")]
public partial class SaleAdvancePaymentInv: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("deposit_account_id")]
    public Guid? DepositAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("advance_payment_method")]
    public string? AdvancePaymentMethod { get; set; }

    [Column("fixed_amount")]
    public decimal? FixedAmount { get; set; }

    [Column("deduct_down_payments")]
    public bool? DeductDownPayments { get; set; }

    [Column("consolidated_billing")]
    public bool? ConsolidatedBilling { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("date_start_invoice_timesheet")]
    public DateTime? DateStartInvoiceTimesheet { get; set; }

    [Column("date_end_invoice_timesheet")]
    public DateTime? DateEndInvoiceTimesheet { get; set; }

    [Column("invoicing_timesheet_enabled")]
    public bool? InvoicingTimesheetEnabled { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SaleAdvancePaymentInv")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SaleAdvancePaymentInvCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("SaleAdvancePaymentInv")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("DepositAccountId")]
    // [InverseProperty("SaleAdvancePaymentInv")] //Many2one
    public virtual AccountAccount? DepositAccount { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("SaleAdvancePaymentInv")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SaleAdvancePaymentInvWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleAdvancePaymentInvId")] //Many2many
    // [InverseProperty("SaleAdvancePaymentInv")] //Many2many
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SaleAdvancePaymentInvId")] //Many2many
    // [InverseProperty("SaleAdvancePaymentInv")] //Many2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
