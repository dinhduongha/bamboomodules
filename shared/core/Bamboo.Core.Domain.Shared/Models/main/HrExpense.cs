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

[Table("hr_expense")]
//[Index("SheetId", Name = "hr_expense__sheet_id_index")]
//[Index("State", Name = "hr_expense__state_index")]
public partial class HrExpense : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("sheet_id")]
    public Guid? SheetId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("vendor_id")]
    public Guid? VendorId { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("payment_mode")]
    public string? PaymentMode { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("accounting_date")]
    public DateTime? AccountingDate { get; set; }

    [JsonField] // AnalyticDistribution
    [Column("analytic_distribution", TypeName = "jsonb")]
    public JsonElement? AnalyticDistribution { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("tax_amount_currency")]
    public decimal? TaxAmountCurrency { get; set; }

    [Column("tax_amount")]
    public decimal? TaxAmount { get; set; }

    [Column("total_amount_currency")]
    public decimal? TotalAmountCurrency { get; set; }

    [Column("untaxed_amount_currency")]
    public decimal? UntaxedAmountCurrency { get; set; }

    [Column("total_amount")]
    public decimal? TotalAmount { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountId")]
    public virtual AccountAccount? Account { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExpenseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Expense")] // One2many
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

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
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExpenseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Expense")] // One2many
    public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExpenseId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Expense")] // One2many
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductUomId")]
    public virtual UomUom? ProductUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderId")]
    public virtual SaleOrder? SaleOrder { get; set; }

    // CONFLICK-V19
    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("ExpenseId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Expense")] // One2many
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SheetId")]
    public virtual HrExpenseSheet? Sheet { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("VendorId")]
    public virtual ResPartner? Vendor { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrExpenseId")] //Many2many // Hidden
    // [InverseProperty("HrExpense")] //Many2many // Hidden
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicate { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ExpenseId")] // Many2many // Normal
    // [InverseProperty("Expense")] // Many2many // Normal
    public virtual ICollection<AccountTax> Tax { get; set; }
}
