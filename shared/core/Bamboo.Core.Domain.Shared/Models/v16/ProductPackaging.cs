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

[Table("product_packaging")]
//[Index("CompanyId", Name = "product_packaging__company_id_index")]
//[Index("Barcode", Name = "product_packaging_barcode_uniq", IsUnique = true)]
public partial class ProductPackaging: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("qty")]
    public decimal? Qty { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sales")]
    public bool? Sales { get; set; }

    [Column("package_type_id")]
    public Guid? PackageTypeId { get; set; }

    [Column("purchase")]
    public bool? Purchase { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PackageTypeId")]
    public virtual StockPackageType? PackageType { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ProductPackagingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductPackaging")] // One2many
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ProductPackagingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductPackaging")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ProductPackagingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductPackaging")] // One2many
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PackagingId")] //Many2many // Hidden
    // [InverseProperty("Packaging")] //Many2many // Hidden
    public virtual ICollection<StockRoute> Route { get; set; }
}
