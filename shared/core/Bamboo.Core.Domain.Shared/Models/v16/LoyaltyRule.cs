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

[Table("loyalty_rule")]
public partial class LoyaltyRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("program_id")]
    public Guid? ProgramId { get; set; }

    [Column("product_category_id")]
    public Guid? ProductCategoryId { get; set; }

    [Column("product_tag_id")]
    public Guid? ProductTagId { get; set; }

    [Column("minimum_qty")]
    public long? MinimumQty { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("product_domain")]
    public string? ProductDomain { get; set; }

    [Column("reward_point_mode")]
    public string? RewardPointMode { get; set; }

    [Column("minimum_amount_tax_mode")]
    public string? MinimumAmountTaxMode { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("minimum_amount")]
    public decimal? MinimumAmount { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("reward_point_split")]
    public bool? RewardPointSplit { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("reward_point_amount")]
    public double? RewardPointAmount { get; set; }

    [Column("promo_barcode")]
    public string? PromoBarcode { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProductCategoryId")]
    public virtual ProductCategory? ProductCategory { get; set; }

    // [Many2one]
    [ForeignKey("ProductTagId")]
    public virtual ProductTag? ProductTag { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("LoyaltyRuleId")] // Many2many // Normal
    // [InverseProperty("LoyaltyRule")] // Many2many // Normal
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("LoyaltyRuleId")] //Many2many // Hidden
    // [InverseProperty("LoyaltyRule")] //Many2many // Hidden
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
