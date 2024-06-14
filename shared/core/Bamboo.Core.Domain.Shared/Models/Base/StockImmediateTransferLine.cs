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

[Table("stock_immediate_transfer_line")]
public partial class StockImmediateTransferLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("immediate_transfer_id")]
    public Guid? ImmediateTransferId { get; set; }

    [Column("picking_id")]
    public Guid? PickingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("to_immediate")]
    public bool? ToImmediate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("StockImmediateTransferLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ImmediateTransferId")]
    //[InverseProperty("StockImmediateTransferLines")]
    [NotMapped]
    public virtual StockImmediateTransfer? ImmediateTransfer { get; set; }

    [ForeignKey("PickingId")]
    //[InverseProperty("StockImmediateTransferLines")]
    [NotMapped]
    public virtual StockPicking? Picking { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("StockImmediateTransferLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
