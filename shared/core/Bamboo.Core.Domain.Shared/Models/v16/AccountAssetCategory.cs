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

[Table("account_asset_category")]
//[Index("Name", Name = "account_asset_category__name_index")]
//[Index("Type", Name = "account_asset_category__type_index")]
public partial class AccountAssetCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("account_analytic_id")]
    public Guid? AccountAnalyticId { get; set; }

    [Column("account_asset_id")]
    public Guid? AccountAssetId { get; set; }

    [Column("account_depreciation_id")]
    public Guid? AccountDepreciationId { get; set; }

    [Column("account_depreciation_expense_id")]
    public Guid? AccountDepreciationExpenseId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("method_number")]
    public long? MethodNumber { get; set; }

    [Column("method_period")]
    public long? MethodPeriod { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("method")]
    public string? Method { get; set; }

    [Column("method_time")]
    public string? MethodTime { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("date_first_depreciation")]
    public string? DateFirstDepreciation { get; set; }

    [Column("method_end")]
    public DateTime? MethodEnd { get; set; }

    [JsonField]
    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("prorata")]
    public bool? Prorata { get; set; }

    [Column("open_asset")]
    public bool? OpenAsset { get; set; }

    [Column("group_entries")]
    public bool? GroupEntries { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("method_progress_factor")]
    public double? MethodProgressFactor { get; set; }

    // [Many2one]
    [ForeignKey("AccountAnalyticId")]
    // [InverseProperty("AccountAssetCategory")] //Many2one
    public virtual AccountAnalyticAccount? AccountAnalytic { get; set; }

    // [Many2one]
    [ForeignKey("AccountAssetId")]
    // [InverseProperty("AccountAssetCategoryAccountAsset")] //Many2one
    public virtual AccountAccount? AccountAsset { get; set; }

    // [One2many]
    [ForeignKey("CategoryId")]
    [InverseProperty("Category")]
    public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [Many2one]
    [ForeignKey("AccountDepreciationId")]
    // [InverseProperty("AccountAssetCategoryAccountDepreciation")] //Many2one
    public virtual AccountAccount? AccountDepreciation { get; set; }

    // [Many2one]
    [ForeignKey("AccountDepreciationExpenseId")]
    // [InverseProperty("AccountAssetCategoryAccountDepreciationExpense")] //Many2one
    public virtual AccountAccount? AccountDepreciationExpense { get; set; }

    // [One2many]
    [ForeignKey("AssetCategoryId")]
    [InverseProperty("AssetCategory")]
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountAssetCategory")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAssetCategoryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("AccountAssetCategory")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountAssetCategory")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAssetCategoryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
