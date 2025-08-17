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

[Table("product_supplierinfo")]
//[Index("CompanyId", Name = "product_supplierinfo_company_id_index")]
//[Index("ProductTmplId", Name = "product_supplierinfo_product_tmpl_id_index")]
public partial class ProductSupplierinfo: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("delay")]
    public long? Delay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("product_name")]
    public string? ProductName { get; set; }

    [Column("product_code")]
    public string? ProductCode { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("min_qty")]
    public decimal? MinQty { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("purchase_requisition_line_id")]
    public Guid? PurchaseRequisitionLineId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ProductSupplierinfo")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductSupplierinfoCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("ProductSupplierinfo")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ProductSupplierinfo")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("ProductSupplierinfo")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("ProductTmplId")]
    // [InverseProperty("ProductSupplierinfo")] //Many2one
    public virtual ProductTemplate? ProductTmpl { get; set; }

    // [Many2one]
    [ForeignKey("PurchaseRequisitionLineId")]
    // [InverseProperty("ProductSupplierinfo")] //Many2one
    public virtual PurchaseRequisitionLine? PurchaseRequisitionLine { get; set; }

    // [One2many]
    [ForeignKey("SupplierId")]
    [InverseProperty("Supplier")]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductSupplierinfoWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductSupplierinfoId")]
    // [InverseProperty("ProductSupplierinfo")]
    // public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfo { get; set; }
}
