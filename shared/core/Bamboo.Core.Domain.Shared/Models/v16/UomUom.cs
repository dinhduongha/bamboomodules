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

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (AccountAnalyticLine) is commented out
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("AssociatedUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AssociatedUom")] // One2many // Peer relationship (BarcodeRule) is commented out
    // public virtual ICollection<BarcodeRule> BarcodeRule { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    public virtual UomCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpBom) is commented out
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpBomByproduct) is commented out
    // public virtual ICollection<MrpBomByproduct> MrpBomByproduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpBomLine) is commented out
    // public virtual ICollection<MrpBomLine> MrpBomLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpProduction) is commented out
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpUnbuild) is commented out
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpWorkorder) is commented out
    // public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (ProductReplenish) is commented out
    // public virtual ICollection<ProductReplenish> ProductReplenish { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Uom")] // One2many // Peer relationship (ProductTemplate) is commented out
    // public virtual ICollection<ProductTemplate> ProductTemplateUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomPoId")]
    // [NotMapped] // One2many 
    // [InverseProperty("UomPo")] // One2many // Peer relationship (ProductTemplate) is commented out
    // public virtual ICollection<ProductTemplate> ProductTemplateUomPo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Uom")] // One2many // Peer relationship (ProjectUpdate) is commented out
    // public virtual ICollection<ProjectUpdate> ProjectUpdate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (PurchaseOrderLine) is commented out
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (PurchaseRequisitionLine) is commented out
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProjectTimeModeId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProjectTimeMode")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyProjectTimeMode { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("TimesheetEncodeUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("TimesheetEncodeUom")] // One2many
    // public virtual ICollection<ResCompany> ResCompanyTimesheetEncodeUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (SaleOrderLine) is commented out
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Uom")] // One2many // Peer relationship (SaleOrderOption) is commented out
    // public virtual ICollection<SaleOrderOption> SaleOrderOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (SaleOrderTemplateLine) is commented out
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Uom")] // One2many // Peer relationship (SaleOrderTemplateOption) is commented out
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOption { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (StockLot) is commented out
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (StockMoveLine) is commented out
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (StockScrap) is commented out
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
