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

[Table("stock_warn_insufficient_qty_unbuild")]
public partial class StockWarnInsufficientQtyUnbuild: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("location_id")]
    public Guid? LocationId { get; set; }

    [Column("unbuild_id")]
    public Guid? UnbuildId { get; set; }

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
    //[InverseProperty("StockWarnInsufficientQtyUnbuildCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LocationId")]
    //[InverseProperty("StockWarnInsufficientQtyUnbuilds")]
    [NotMapped]
    public virtual StockLocation? Location { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockWarnInsufficientQtyUnbuilds")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("UnbuildId")]
    //[InverseProperty("StockWarnInsufficientQtyUnbuilds")]
    [NotMapped]
    public virtual MrpUnbuild? Unbuild { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockWarnInsufficientQtyUnbuildWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
