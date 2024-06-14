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
public partial class StockReturnPicking: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("original_location_id")]
    public Guid? OriginalLocationId { get; set; }

    [Column("parent_location_id")]
    public Guid? ParentLocationId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("move_dest_exists")]
    public bool? MoveDestExists { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockReturnPickingCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockReturnPickingLocations")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("OriginalLocationId")]
    //[InverseProperty("StockReturnPickingOriginalLocations")]
    [NotMapped]
    public virtual StockLocation? OriginalLocation { get; set; }

    [ForeignKey("ParentLocationId")]
    //[InverseProperty("StockReturnPickingParentLocations")]
    [NotMapped]
    public virtual StockLocation? ParentLocation { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockReturnPickings")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockReturnPickingWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Wizard")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLines { get; } = new List<StockReturnPickingLine>();

}
