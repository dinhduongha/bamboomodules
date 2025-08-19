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

[Table("stock_landed_cost")]
public partial class StockLandedCost: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("account_move_id")]
    public Guid? AccountMoveId { get; set; }

    [Column("account_journal_id")]
    public Guid? AccountJournalId { get; set; }

    [Column("vendor_bill_id")]
    public Guid? VendorBillId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("target_model")]
    public string? TargetModel { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("amount_total")]
    public decimal? AmountTotal { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalId")]
    // [InverseProperty("StockLandedCost")] //Many2one
    public virtual AccountJournal? AccountJournal { get; set; }

    // [Many2one]
    [ForeignKey("AccountMoveId")]
    // [InverseProperty("StockLandedCostAccountMove")] //Many2one
    public virtual AccountMove? AccountMove { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockLandedCost")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockLandedCostCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("StockLandedCost")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("CostId")]
    [InverseProperty("Cost")]
    public virtual ICollection<StockLandedCostLines> StockLandedCostLines { get; set; }

    // [One2many]
    [ForeignKey("CostId")]
    [InverseProperty("Cost")]
    public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLines { get; set; }

    // [One2many]
    [ForeignKey("StockLandedCostId")]
    [InverseProperty("StockLandedCost")]
    public virtual ICollection<StockValuationLayer> StockValuationLayer { get; set; }

    // [Many2one]
    [ForeignKey("VendorBillId")]
    // [InverseProperty("StockLandedCostVendorBill")] //Many2one
    public virtual AccountMove? VendorBill { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockLandedCostWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("StockLandedCostId")] //Many2many
    // [InverseProperty("StockLandedCost")] //Many2many
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("StockLandedCostId")] //Many2many
    // [InverseProperty("StockLandedCost")] //Many2many
    public virtual ICollection<StockPicking> StockPicking { get; set; }
}
