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

[Table("stock_package_type")]
//[Index("CompanyId", Name = "stock_package_type__company_id_index")]
//[Index("Barcode", Name = "stock_package_type_barcode_uniq", IsUnique = true)]
public partial class StockPackageType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("height")]
    public double? Height { get; set; }

    [Column("width")]
    public double? Width { get; set; }

    [Column("packaging_length")]
    public double? PackagingLength { get; set; }

    [Column("base_weight")]
    public double? BaseWeight { get; set; }

    [Column("max_weight")]
    public double? MaxWeight { get; set; }

    [Column("shipper_package_code")]
    public string? ShipperPackageCode { get; set; }

    [Column("package_carrier_type")]
    public string? PackageCarrierType { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("DeliveryPackageTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DeliveryPackageType")] // One2many
    public virtual ICollection<ChooseDeliveryPackage> ChooseDeliveryPackage { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PackageTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackageType")] // One2many
    public virtual ICollection<ProductPackaging> ProductPackaging { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PackageTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackageType")] // One2many
    public virtual ICollection<StockQuantPackage> StockQuantPackage { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PackageTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackageType")] // One2many
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacity { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPackageTypeId")] //Many2many // Hidden
    // [InverseProperty("StockPackageType")] //Many2many // Hidden
    public virtual ICollection<StockPutawayRule> StockPutawayRule { get; set; }
}
