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
//[Index("TenantId", Name = "stock_package_level_company_id_index")]
public partial class StockPackageLevel: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("package_id")]
    public Guid? PackageId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("StockPackageLevels")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockPackageLevelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("StockPackageLevels")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("PackageId")]
    //[InverseProperty("StockPackageLevels")]
    [NotMapped]
    public virtual StockQuantPackage? Package { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockPackageLevels")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockPackageLevelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("PackageLevel")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("PackageLevel")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();
}
