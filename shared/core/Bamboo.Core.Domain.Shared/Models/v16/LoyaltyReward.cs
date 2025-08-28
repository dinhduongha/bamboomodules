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

[Table("loyalty_reward")]
public partial class LoyaltyReward: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("discount_product_category_id")]
    public Guid? DiscountProductCategoryId { get; set; }

    [Column("discount_product_tag_id")]
    public Guid? DiscountProductTagId { get; set; }

    [Column("discount_line_product_id")]
    public Guid? DiscountLineProductId { get; set; }

    [Column("reward_product_id")]
    public Guid? RewardProductId { get; set; }

    [Column("reward_product_tag_id")]
    public Guid? RewardProductTagId { get; set; }

    [Column("reward_product_qty")]
    public long? RewardProductQty { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("reward_type")]
    public string? RewardType { get; set; }

    [Column("discount_mode")]
    public string? DiscountMode { get; set; }

    [Column("discount_applicability")]
    public string? DiscountApplicability { get; set; }

    [Column("discount_product_domain")]
    public string? DiscountProductDomain { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("discount_max_amount")]
    public decimal? DiscountMaxAmount { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("clear_wallet")]
    public bool? ClearWallet { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("discount")]
    public double? Discount { get; set; }

    [Column("required_points")]
    public double? RequiredPoints { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DiscountLineProductId")]
    public virtual ProductProduct? DiscountLineProduct { get; set; }

    // [Many2one]
    [ForeignKey("DiscountProductCategoryId")]
    public virtual ProductCategory? DiscountProductCategory { get; set; }

    // [Many2one]
    [ForeignKey("DiscountProductTagId")]
    public virtual ProductTag? DiscountProductTag { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RewardId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Reward")] // One2many
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("RewardProductId")]
    public virtual ProductProduct? RewardProduct { get; set; }

    // [Many2one]
    [ForeignKey("RewardProductTagId")]
    public virtual ProductTag? RewardProductTag { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SelectedRewardId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SelectedReward")] // One2many
    public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizard { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RewardId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Reward")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("LoyaltyRewardId")] // Many2many // Normal
    // [InverseProperty("LoyaltyReward")] // Many2many // Normal
    public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("LoyaltyRewardId")] // Many2many // Normal
    // [InverseProperty("LoyaltyReward")] // Many2many // Normal
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("LoyaltyRewardId")] //Many2many // Hidden
    // [InverseProperty("LoyaltyReward")] //Many2many // Hidden
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
