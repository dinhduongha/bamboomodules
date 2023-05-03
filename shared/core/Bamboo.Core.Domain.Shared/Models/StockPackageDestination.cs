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

[Table("stock_package_destination")]
public partial class StockPackageDestination: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("location_dest_id")]
    public Guid? LocationDestId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockPackageDestinationCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationDestId")]
    //[InverseProperty("StockPackageDestinations")]
    [NotMapped]
    public virtual StockLocation? LocationDest { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockPackageDestinations")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockPackageDestinationWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
