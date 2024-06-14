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

[Table("sale_order_option")]
//[Index("OrderId", Name = "sale_order_option_order_id_index")]
public partial class SaleOrderOption: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("line_id")]
    public Guid? LineId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("uom_id")]
    public Guid? UomId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("discount")]
    public decimal? Discount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderOptionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LineId")]
    //[InverseProperty("SaleOrderOptions")]
    [NotMapped]
    public virtual SaleOrderLine? Line { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("SaleOrderOptions")]
    [NotMapped]
    public virtual SaleOrder? Order { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("SaleOrderOptions")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("UomId")]
    //[InverseProperty("SaleOrderOptions")]
    [NotMapped]
    public virtual UomUom? Uom { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderOptionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
