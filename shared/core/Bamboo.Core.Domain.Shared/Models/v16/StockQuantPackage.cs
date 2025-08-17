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

[Table("stock_quant_package")]
//[Index("CompanyId", Name = "stock_quant_package_company_id_index")]
//[Index("LocationId", Name = "stock_quant_package_location_id_index")]
//[Index("PackageTypeId", Name = "stock_quant_package_package_type_id_index")]
public partial class StockQuantPackage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("package_type_id")]
    public Guid? PackageTypeId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("package_use")]
    public string? PackageUse { get; set; }

    [Column("pack_date")]
    public DateTime? PackDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("shipping_weight")]
    public double? ShippingWeight { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockQuantPackage")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockQuantPackageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationId")]
    // [InverseProperty("StockQuantPackage")] //Many2one
    public virtual StockLocation? Location { get; set; }

    // [Many2one]
    [ForeignKey("PackageTypeId")]
    // [InverseProperty("StockQuantPackage")] //Many2one
    public virtual StockPackageType? PackageType { get; set; }

    // [One2many]
    [ForeignKey("PackageId")]
    [InverseProperty("Package")]
    public virtual ICollection<StockMoveLine> StockMoveLinePackage { get; set; }

    // [One2many]
    [ForeignKey("ResultPackageId")]
    [InverseProperty("ResultPackage")]
    public virtual ICollection<StockMoveLine> StockMoveLineResultPackage { get; set; }

    // [One2many]
    [ForeignKey("PackageId")]
    [InverseProperty("Package")]
    public virtual ICollection<StockPackageLevel> StockPackageLevel { get; set; }

    // [One2many]
    [ForeignKey("PackageId")]
    [InverseProperty("Package")]
    public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many]
    [ForeignKey("PackageId")]
    [InverseProperty("Package")]
    public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockQuantPackageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
