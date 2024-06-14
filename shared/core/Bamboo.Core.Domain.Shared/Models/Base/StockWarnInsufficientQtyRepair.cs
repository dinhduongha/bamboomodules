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

[Table("stock_warn_insufficient_qty_repair")]
public partial class StockWarnInsufficientQtyRepair: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("repair_id")]
    public Guid? RepairId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("product_uom_name")]
    public string? ProductUomName { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("quantity")]
    public double? Quantity { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockWarnInsufficientQtyRepairCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockWarnInsufficientQtyRepairs")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockWarnInsufficientQtyRepairs")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("RepairId")]
    //[InverseProperty("StockWarnInsufficientQtyRepairs")]
    [NotMapped]
    public virtual RepairOrder? Repair { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockWarnInsufficientQtyRepairWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
