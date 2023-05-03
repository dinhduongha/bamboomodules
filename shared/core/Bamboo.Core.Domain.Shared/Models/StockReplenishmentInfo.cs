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

[Table("stock_replenishment_info")]
public partial class StockReplenishmentInfo: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("orderpoint_id")]
    public Guid? OrderpointId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockReplenishmentInfoCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OrderpointId")]
    //[InverseProperty("StockReplenishmentInfos")]
    [NotMapped]
    public virtual StockWarehouseOrderpoint? Orderpoint { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockReplenishmentInfoWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ReplenishmentInfo")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptions { get; } = new List<StockReplenishmentOption>();

    [ForeignKey("StockReplenishmentInfoId")]
    //[InverseProperty("StockReplenishmentInfos")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; } = new List<ProductSupplierinfo>();
}
