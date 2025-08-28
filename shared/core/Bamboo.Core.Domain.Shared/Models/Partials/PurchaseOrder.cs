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

//[Table("purchase_order")]
//[Index("CompanyId", Name = "purchase_order__company_id_index")]
//[Index("DateApprove", Name = "purchase_order__date_approve_index")]
//[Index("DateOrder", Name = "purchase_order__date_order_index")]
//[Index("DatePlanned", Name = "purchase_order__date_planned_index")]
//[Index("Priority", Name = "purchase_order__priority_index")]
//[Index("State", Name = "purchase_order__state_index")]
//[Index("UserId", Name = "purchase_order__user_id_index")]
public partial class PurchaseOrder
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    // v16-Compat
    //[Column("currency_rate")]
    //public double? CurrencyRate { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
