using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("stock_picking")]
//[Index("BatchId", Name = "stock_picking__batch_id_index")]
//[Index("CompanyId", Name = "stock_picking__company_id_index")]
//[Index("PickingTypeId", Name = "stock_picking__picking_type_id_index")]
//[Index("PosOrderId", Name = "stock_picking__pos_order_id_index")]
//[Index("PosSessionId", Name = "stock_picking__pos_session_id_index")]
//[Index("ScheduledDate", Name = "stock_picking__scheduled_date_index")]
//[Index("State", Name = "stock_picking__state_index")]
//[Index("Name", "CompanyId", Name = "stock_picking_name_uniq", IsUnique = true)]
public partial class StockPicking
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("immediate_transfer")]
    public bool? ImmediateTransfer { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    // [ForeignKey("SaleId")]
    // public virtual SaleOrder? Sale { get; set; }

    // v16-Compat
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PickingId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    // public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLine { get; set; }

    [One2many]
    // [One2many] [ForeignKey("PickingId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Picking")] // One2many
    public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<LotLabelLayout> LotLabelLayout { get; set; }

    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    // public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockPickingId")] //Many2many // Hidden
    // [InverseProperty("StockPicking")] //Many2many // Hidden
    public virtual ICollection<StockImmediateTransfer> StockImmediateTransfer { get; set; }
}
