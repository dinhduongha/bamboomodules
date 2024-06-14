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

[Table("stock_return_picking_line")]
public partial class StockReturnPickingLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("quantity")]
    public decimal? Quantity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("to_refund")]
    public bool? ToRefund { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockReturnPickingLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("StockReturnPickingLines")]
    [NotMapped]
    public virtual StockMove? Move { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("StockReturnPickingLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("StockReturnPickingLines")]
    [NotMapped]
    public virtual StockReturnPicking? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockReturnPickingLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
