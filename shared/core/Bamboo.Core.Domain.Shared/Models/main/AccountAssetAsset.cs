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

[Table("account_asset_asset")]
public partial class AccountAssetAsset : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("method_number")]
    public long? MethodNumber { get; set; }

    [Column("method_period")]
    public long? MethodPeriod { get; set; }

    [Column("invoice_id")]
    public Guid? InvoiceId { get; set; }

    [Column("account_analytic_id")]
    public Guid? AccountAnalyticId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("method")]
    public string? Method { get; set; }

    [Column("method_time")]
    public string? MethodTime { get; set; }

    [Column("date_first_depreciation")]
    public string? DateFirstDepreciation { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("method_end")]
    public DateTime? MethodEnd { get; set; }

    [Column("first_depreciation_manual_date")]
    public DateTime? FirstDepreciationManualDate { get; set; }

    [JsonField] // AnalyticDistribution
    [Column("analytic_distribution", TypeName = "jsonb")]
    public JsonElement? AnalyticDistribution { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("value")]
    public decimal? Value { get; set; }

    [Column("salvage_value")]
    public decimal? SalvageValue { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("prorata")]
    public bool? Prorata { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("method_progress_factor")]
    public double? MethodProgressFactor { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountAnalyticId")]
    public virtual AccountAnalyticAccount? AccountAnalytic { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AssetId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Asset")] // One2many
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategoryId")]
    public virtual AccountAssetCategory? Category { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InvoiceId")]
    public virtual AccountMove? Invoice { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
