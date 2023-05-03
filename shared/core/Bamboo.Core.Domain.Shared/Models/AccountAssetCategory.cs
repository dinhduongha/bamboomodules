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
//[Index("Name", Name = "account_asset_category_name_index")]
//[Index("Type", Name = "account_asset_category_type_index")]
public partial class AccountAssetCategory: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

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

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("method_number")]
    public long? MethodNumber { get; set; }

    [Column("method_period")]
    public long? MethodPeriod { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("method_progress_factor")]
    public double? MethodProgressFactor { get; set; }

    [ForeignKey("AccountAnalyticId")]
    //[InverseProperty("AccountAssetCategories")]
    [NotMapped]
    public virtual AccountAnalyticAccount? AccountAnalytic { get; set; }

    [ForeignKey("AccountAssetId")]
    //[InverseProperty("AccountAssetCategoryAccountAssets")]
    [NotMapped]
    public virtual AccountAccount? AccountAsset { get; set; }


    [ForeignKey("AccountDepreciationId")]
    //[InverseProperty("AccountAssetCategoryAccountDepreciations")]
    [NotMapped]
    public virtual AccountAccount? AccountDepreciation { get; set; }

    [ForeignKey("AccountDepreciationExpenseId")]
    //[InverseProperty("AccountAssetCategoryAccountDepreciationExpenses")]
    [NotMapped]
    public virtual AccountAccount? AccountDepreciationExpense { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAssetCategories")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAssetCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("AccountAssetCategories")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAssetCategories")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAssetCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } = new List<AccountAssetAsset>();

    //[InverseProperty("AssetCategory")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

}
