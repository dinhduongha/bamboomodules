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

[Table("account_asset_depreciation_line")]
//[Index("DepreciationDate", Name = "account_asset_depreciation_line_depreciation_date_index")]
//[Index("Name", Name = "account_asset_depreciation_line_name_index")]
public partial class AccountAssetDepreciationLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("asset_id")]
    public Guid? AssetId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("depreciation_date")]
    public DateTime? DepreciationDate { get; set; }

    [Column("amount")]
    public decimal? Amount { get; set; }

    [Column("remaining_value")]
    public decimal? RemainingValue { get; set; }

    [Column("depreciated_value")]
    public decimal? DepreciatedValue { get; set; }

    [Column("move_check")]
    public bool? MoveCheck { get; set; }

    [Column("move_posted_check")]
    public bool? MovePostedCheck { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AssetId")]
    //[InverseProperty("AccountAssetDepreciationLines")]
    [NotMapped]
    public virtual AccountAssetAsset? Asset { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAssetDepreciationLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("AccountAssetDepreciationLines")]
    [NotMapped]
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAssetDepreciationLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
