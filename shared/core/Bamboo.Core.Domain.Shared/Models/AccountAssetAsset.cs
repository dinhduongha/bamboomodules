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

[Table("account_asset_asset")]
public partial class AccountAssetAsset: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("method_progress_factor")]
    public double? MethodProgressFactor { get; set; }

    [ForeignKey("AccountAnalyticId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual AccountAnalyticAccount? AccountAnalytic { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual AccountAssetCategory? Category { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAssetAssetCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("InvoiceId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual AccountMove? Invoice { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountAssetAssets")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAssetAssetWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Asset")]
    [NotMapped]
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLines { get; } = new List<AccountAssetDepreciationLine>();

}
