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

[Table("stock_return_picking")]
public partial class StockReturnPicking : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    // v16-Compat
    [Column("original_location_id")]
    public Guid? OriginalLocationId { get; set; }

    // v16-Compat
    [Column("parent_location_id")]
    public Guid? ParentLocationId { get; set; }

    // v16-Compat
    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    // v16-Compat
    [Column("move_dest_exists")]
    public bool? MoveDestExists { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockReturnPickingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("LocationId")]
    //[InverseProperty("StockReturnPickingLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    // v16-Compat
    [ForeignKey("OriginalLocationId")]
    //[InverseProperty("StockReturnPickingOriginalLocations")]
    [NotMapped]
    public virtual StockLocation? OriginalLocation { get; set; }

    // v16-Compat
    [ForeignKey("ParentLocationId")]
    //[InverseProperty("StockReturnPickingParentLocations")]
    [NotMapped]
    public virtual StockLocation? ParentLocation { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockReturnPickings")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    //[InverseProperty("Wizard")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLines { get; set; } = new List<StockReturnPickingLine>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockReturnPickingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
