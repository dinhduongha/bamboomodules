using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class AssetAssetReport: Entity<Guid>, IMultiTenant
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("depreciation_date")]
    public DateTime? DepreciationDate { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("gross_value")]
    public decimal? GrossValue { get; set; }

    [Column("depreciation_value")]
    public decimal? DepreciationValue { get; set; }

    [Column("installment_value")]
    public decimal? InstallmentValue { get; set; }

    [Column("posted_value")]
    public decimal? PostedValue { get; set; }

    [Column("unposted_value")]
    public decimal? UnpostedValue { get; set; }

    [Column("asset_id")]
    public Guid? AssetId { get; set; }

    [Column("move_check")]
    public bool? MoveCheck { get; set; }

    [Column("asset_category_id")]
    public Guid? AssetCategoryId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("installment_nbr")]
    public long? InstallmentNbr { get; set; }

    [Column("depreciation_nbr")]
    public long? DepreciationNbr { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
}
