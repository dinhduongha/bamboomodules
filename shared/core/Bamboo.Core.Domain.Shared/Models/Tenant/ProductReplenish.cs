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

[Table("product_replenish")]
public partial class ProductReplenish: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("product_uom_id")]
    public Guid? ProductUomId { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("product_has_variants")]
    public bool? ProductHasVariants { get; set; }

    [Column("date_planned", TypeName = "timestamp without time zone")]
    public DateTime? DatePlanned { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("quantity")]
    public double? Quantity { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ProductReplenishes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductReplenishCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("ProductReplenishes")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("ProductReplenishes")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("ProductUomId")]
    //[InverseProperty("ProductReplenishes")]
    [NotMapped]
    public virtual UomUom? ProductUom { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("ProductReplenishes")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductReplenishWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ProductReplenishId")]
    //[InverseProperty("ProductReplenishes")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRoutes { get; } = new List<StockRoute>();
}
