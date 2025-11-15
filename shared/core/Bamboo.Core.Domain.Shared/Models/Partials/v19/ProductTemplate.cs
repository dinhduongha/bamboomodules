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

public partial class ProductTemplate
{
    [Column("lot_sequence_id")]
    public Guid? LotSequenceId { get; set; }


    [JsonField] // PropertyPriceDifferenceAccountId
    [Column("property_price_difference_account_id", TypeName = "jsonb")]
    public JsonElement? PropertyPriceDifferenceAccountId { get; set; }

    // [JsonField] // ServiceToPurchase
    // [Column("service_to_purchase", TypeName = "jsonb")]
    // public JsonElement? ServiceToPurchase { get; set; }

    [Column("variants_default_code")]
    public string? VariantsDefaultCode { get; set; }

    [Column("is_seo_optimized")]
    public bool? IsSeoOptimized { get; set; }

    [Column("publish_date", TypeName = "timestamp without time zone")]
    public DateTime? PublishDate { get; set; }

    // [JsonField] // ProjectId
    // [Column("project_id", TypeName = "jsonb")]
    // public JsonElement? ProjectId { get; set; }

    // [JsonField] // ProjectTemplateId
    // [Column("project_template_id", TypeName = "jsonb")]
    // public JsonElement? ProjectTemplateId { get; set; }

    [JsonField] // TaskTemplateId
    [Column("task_template_id", TypeName = "jsonb")]
    public JsonElement? TaskTemplateId { get; set; }

    [Column("pos_sequence")]
    public long? PosSequence { get; set; }

    // [JsonField(IsSparse = false)] // PublicDescription
    // [Column("public_description", TypeName = "jsonb")]
    // public StringDictionary? PublicDescription { get; set; }

    // [JsonField] // AssetCategoryId
    // [Column("asset_category_id", TypeName = "jsonb")]
    // public JsonElement? AssetCategoryId { get; set; }

    // [JsonField] // DeferredRevenueCategoryId
    // [Column("deferred_revenue_category_id", TypeName = "jsonb")]
    // public JsonElement? DeferredRevenueCategoryId { get; set; }

    [Column("grade_id")]
    public Guid? GradeId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GradeId")]
    public virtual ResPartnerGrade? Grade { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LotSequenceId")]
    public virtual IrSequence? LotSequence { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SrcId")] // Many2many // Normal
    // [InverseProperty("Src")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> Dest { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("SrcId")] // Many2many // Normal
    // [InverseProperty("Src1")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> Dest2 { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("SrcId")] // Many2many // Normal
    // [InverseProperty("Src")] // Many2many // Normal
    public virtual ICollection<ProductProduct> DestNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DestId")] // Many2many // Normal
    // [InverseProperty("Dest2")] // Many2many // Normal
    public virtual ICollection<ProductTemplate> Src1 { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (UomUom) is commented out
    // [ForeignKey("ProductTemplateId")] // Many2many // Normal
    // [InverseProperty("ProductTemplateNavigation")] // Many2many // Normal
    public virtual ICollection<UomUom> UomUom { get; set; }

}