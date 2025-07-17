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
//[Index("Barcode", Name = "stock_package_type_barcode_uniq", IsUnique = true)]
//[Index("TenantId", Name = "stock_package_type_company_id_index")]
public partial class StockPackageType : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("height")]
    public double? Height { get; set; }

    [Column("width")]
    public double? Width { get; set; }

    [Column("packaging_length")]
    public double? PackagingLength { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("base_weight")]
    public double? BaseWeight { get; set; }

    [Column("max_weight")]
    public double? MaxWeight { get; set; }

    [Column("shipper_package_code")]
    public string? ShipperPackageCode { get; set; }

    [Column("package_carrier_type")]
    public string? PackageCarrierType { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockPackageTypes")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockPackageTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockPackageTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("PackageType")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagings { get; set; } = new List<ProductPackaging>();

    //[InverseProperty("PackageType")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackages { get; set; } = new List<StockQuantPackage>();

    //[InverseProperty("PackageType")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacities { get; set; } = new List<StockStorageCategoryCapacity>();

    [ForeignKey("StockPackageTypeId")]
    //[InverseProperty("StockPackageTypes")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRules { get; set; } = new List<StockPutawayRule>();
}
