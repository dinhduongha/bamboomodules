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

[Table("uom_uom")]
public partial class UomUom: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("uom_type")]
    public string? UomType { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("factor")]
    public decimal? Factor { get; set; }

    [Column("rounding")]
    public decimal? Rounding { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("timesheet_widget")]
    public string? TimesheetWidget { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many]
    [ForeignKey("AssociatedUomId")]
    [InverseProperty("AssociatedUom")]
    public virtual ICollection<BarcodeRule> BarcodeRule { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("UomUom")] //Many2one
    public virtual UomCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("UomUomCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many]
    [ForeignKey("UomId")]
    [InverseProperty("Uom")]
    public virtual ICollection<ProductTemplate> ProductTemplateUom { get; set; }

    // [One2many]
    [ForeignKey("UomPoId")]
    [InverseProperty("UomPo")]
    public virtual ICollection<ProductTemplate> ProductTemplateUomPo { get; set; }

    // [One2many]
    [ForeignKey("ProductUom")]
    [InverseProperty("ProductUomNavigation")]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [One2many]
    [ForeignKey("ProductUom")]
    [InverseProperty("ProductUomNavigation")]
    public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many]
    [ForeignKey("ProductUom")]
    [InverseProperty("ProductUomNavigation")]
    public virtual ICollection<RepairLine> RepairLine { get; set; }

    // [One2many]
    [ForeignKey("ProductUom")]
    [InverseProperty("ProductUomNavigation")]
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [ForeignKey("ProjectTimeModeId")]
    [InverseProperty("ProjectTimeMode")]
    public virtual ICollection<ResCompany> ResCompanyProjectTimeMode { get; set; }

    // [One2many]
    [ForeignKey("TimesheetEncodeUomId")]
    [InverseProperty("TimesheetEncodeUom")]
    public virtual ICollection<ResCompany> ResCompanyTimesheetEncodeUom { get; set; }

    // [One2many]
    [ForeignKey("ProductUom")]
    [InverseProperty("ProductUomNavigation")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many]
    [ForeignKey("UomId")]
    [InverseProperty("Uom")]
    public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many]
    [ForeignKey("UomId")]
    [InverseProperty("Uom")]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many]
    [ForeignKey("ProductUom")]
    [InverseProperty("ProductUomNavigation")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many]
    [ForeignKey("ProductUomId")]
    [InverseProperty("ProductUom")]
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("UomUomWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
