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

[Table("stock_replenishment_option")]
public partial class StockReplenishmentOption: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("replenishment_info_id")]
    public Guid? ReplenishmentInfoId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockReplenishmentOptionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockReplenishmentOptions")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ReplenishmentInfoId")]
    //[InverseProperty("StockReplenishmentOptions")]
    [NotMapped]
    public virtual StockReplenishmentInfo? ReplenishmentInfo { get; set; }

    [ForeignKey("RouteId")]
    //[InverseProperty("StockReplenishmentOptions")]
    [NotMapped]
    public virtual StockRoute? Route { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockReplenishmentOptionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
