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

[Table("stock_package_level")]
//[Index("CompanyId", Name = "stock_package_level_company_id_index")]
public partial class StockPackageLevel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("package_id")]
    public Guid? PackageId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("StockPackageLevel")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("StockPackageLevelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LocationDestId")]
    // [InverseProperty("StockPackageLevel")] //Many2one
    public virtual StockLocation? LocationDest { get; set; }

    // [Many2one]
    [ForeignKey("PackageId")]
    // [InverseProperty("StockPackageLevel")] //Many2one
    public virtual StockQuantPackage? Package { get; set; }

    // [Many2one]
    [ForeignKey("PickingId")]
    // [InverseProperty("StockPackageLevel")] //Many2one
    public virtual StockPicking? Picking { get; set; }

    // [One2many]
    [ForeignKey("PackageLevelId")]
    [InverseProperty("PackageLevel")]
    public virtual ICollection<StockMove> StockMove { get; set; }

    // [One2many]
    [ForeignKey("PackageLevelId")]
    [InverseProperty("PackageLevel")]
    public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("StockPackageLevelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
