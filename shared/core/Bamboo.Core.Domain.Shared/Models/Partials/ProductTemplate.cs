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

//[Table("product_template")]
//[Index("CompanyId", Name = "product_template__company_id_index")]
//[Index("IsPublished", Name = "product_template__is_published_index")]
//[Index("WebsiteId", Name = "product_template__website_id_index")]
//[Index("WebsiteSequence", Name = "product_template__website_sequence_index")]
public partial class ProductTemplate
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("detailed_type")]
    public string? DetailedType { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("pos_categ_id")]
    public Guid? PosCategId { get; set; }

    [Column("produce_delay")]
    public double? ProduceDelay { get; set; }

    [Column("days_to_prepare_mo")]
    public double? DaysToPrepareMo { get; set; }

    // [Column("service_tracking")]
    // public string? ServiceTracking { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("PosCategId")]
    public virtual PosCategory? PosCateg { get; set; }
}
