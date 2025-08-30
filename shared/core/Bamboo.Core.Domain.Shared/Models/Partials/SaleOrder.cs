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

//[Table("sale_order")]
//[Index("CompanyId", Name = "sale_order__company_id_index")]
//[Index("CreateDate", Name = "sale_order__create_date_index")]
//[Index("PartnerId", Name = "sale_order__partner_id_index")]
//[Index("State", Name = "sale_order__state_index")]
//[Index("UserId", Name = "sale_order__user_id_index")]
//[Index("DateOrder", "Id", Name = "sale_order_date_order_id_idx", AllDescending = true)]
public partial class SaleOrder
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("delivery_rating_success")]
    public bool? DeliveryRatingSuccess { get; set; }

    [Column("amount_delivery")]
    public decimal? AmountDelivery { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleOrderId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("SaleOrder")] // One2many
    public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrder { get; set; }
}
