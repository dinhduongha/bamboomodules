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

//[Table("repair_order")]
//[Index("CompanyId", Name = "repair_order__company_id_index")]
//[Index("InvoiceMethod", Name = "repair_order_invoice_method_index")]
//[Index("LocationId", Name = "repair_order__location_id_index")]
//[Index("Name", Name = "repair_order_name", IsUnique = true)]
//[Index("PartnerId", Name = "repair_order__partner_id_index")]
public partial class RepairOrder
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("partner_invoice_id")]
    public Guid? PartnerInvoiceId { get; set; }

    [Column("invoice_id")]
    public Guid? InvoiceId { get; set; }

    // [Column("move_id")]
    // public Guid? MoveId { get; set; }

    // [Column("user_id")]
    // public Guid? UserId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("invoice_method")]
    public string? InvoiceMethod { get; set; }

    // [Column("schedule_date")]
    // public DateTime? ScheduleDate { get; set; }

    [Column("guarantee_limit")]
    public DateTime? GuaranteeLimit { get; set; }

    [Column("quotation_notes")]
    public string? QuotationNotes { get; set; }

    [Column("invoiced")]
    public bool? Invoiced { get; set; }

    [Column("repaired")]
    public bool? Repaired { get; set; }

    [Column("amount_untaxed")]
    public double? AmountUntaxed { get; set; }

    [Column("amount_tax")]
    public double? AmountTax { get; set; }

    [Column("amount_total")]
    public double? AmountTotal { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceId")]
    public virtual AccountMove? Invoice { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PartnerInvoiceId")]
    public virtual ResPartner? PartnerInvoice { get; set; }

    // [Many2one]
    [ForeignKey("PricelistId")]
    public virtual ProductPricelist? Pricelist { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RepairId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Repair")] // One2many
    public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RepairId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Repair")] // One2many
    public virtual ICollection<RepairLine> RepairLine { get; set; }
}
