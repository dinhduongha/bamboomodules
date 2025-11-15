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

[Table("stock_package")]
//[Index("CompanyId", Name = "stock_package__company_id_index")]
//[Index("LocationId", Name = "stock_package__location_id_index")]
//[Index("PackageTypeId", Name = "stock_package__package_type_id_index")]
//[Index("ParentPath", Name = "stock_package__parent_path_index")]
public partial class StockPackage : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("package_type_id")]
    public Guid? PackageTypeId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("parent_package_id")]
    public Guid? ParentPackageId { get; set; }

    [Column("package_dest_id")]
    public Guid? PackageDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("pack_date")]
    public DateTime? PackDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("shipping_weight")]
    public double? ShippingWeight { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackageDest")] // One2many
    public virtual ICollection<StockPackage> InversePackageDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentPackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentPackage")] // One2many
    public virtual ICollection<StockPackage> InverseParentPackage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LocationId")]
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PackageDestId")]
    public virtual StockPackage? PackageDest { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PackageTypeId")]
    public virtual StockPackageType? PackageType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentPackageId")]
    public virtual StockPackage? ParentPackage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Package")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLinePackage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResultPackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResultPackage")] // One2many
    public virtual ICollection<StockMoveLine> StockMoveLineResultPackage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OutermostDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("OutermostDest")] // One2many
    public virtual ICollection<StockPackageHistory> StockPackageHistoryOutermostDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Package")] // One2many
    public virtual ICollection<StockPackageHistory> StockPackageHistoryPackage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentDest")] // One2many
    public virtual ICollection<StockPackageHistory> StockPackageHistoryParentDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentOrigId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentOrig")] // One2many
    public virtual ICollection<StockPackageHistory> StockPackageHistoryParentOrig { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ResultPackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ResultPackage")] // One2many
    public virtual ICollection<StockPutInPack> StockPutInPackNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Package")] // One2many
    public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DestPackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DestPackage")] // One2many
    public virtual ICollection<StockQuantRelocate> StockQuantRelocate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Package")] // One2many
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPackageId")] //Many2many // Hidden
    // [InverseProperty("StockPackage")] //Many2many // Hidden
    public virtual ICollection<StockPutInPack> StockPutInPack { get; set; }
}
