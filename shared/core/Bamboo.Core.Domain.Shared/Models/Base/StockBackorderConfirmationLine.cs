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

[Table("stock_backorder_confirmation_line")]
public partial class StockBackorderConfirmationLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("backorder_confirmation_id")]
    public Guid? BackorderConfirmationId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("to_backorder")]
    public bool? ToBackorder { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("BackorderConfirmationId")]
    //[InverseProperty("StockBackorderConfirmationLines")]
    [NotMapped]
    public virtual StockBackorderConfirmation? BackorderConfirmation { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockBackorderConfirmationLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockBackorderConfirmationLines")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockBackorderConfirmationLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
