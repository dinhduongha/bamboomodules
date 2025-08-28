using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("stock_lot")]
//[Index("CompanyId", Name = "stock_lot__company_id_index")]
//[Index("ProductId", Name = "stock_lot__product_id_index")]
public partial class StockLot
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("LotId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Lot")] // One2many
    public virtual ICollection<RepairLine> RepairLine { get; set; }
}
