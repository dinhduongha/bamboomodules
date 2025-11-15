using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class SaleOrder
{


    [Column("preferred_payment_method_line_id")]
    public Guid? PreferredPaymentMethodLineId { get; set; }

    // [Column("delivery_message")]
    // public string? DeliveryMessage { get; set; }

    // [JsonField] // PickupLocationData
    // [Column("pickup_location_data", TypeName = "jsonb")]
    // public JsonElement? PickupLocationData { get; set; }

    // [JsonField] // CustomizablePdfFormFields
    // [Column("customizable_pdf_form_fields", TypeName = "jsonb")]
    // public JsonElement? CustomizablePdfFormFields { get; set; }

    // [Column("amount_unpaid")]
    // public decimal? AmountUnpaid { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PreferredPaymentMethodLineId")]
    public virtual AccountPaymentMethodLine? PreferredPaymentMethodLine { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SaleId")] // Many2many // Normal
    // [InverseProperty("Sale")] // Many2many // Normal
    public virtual ICollection<StockReference> ReferenceNavigation { get; set; }

}