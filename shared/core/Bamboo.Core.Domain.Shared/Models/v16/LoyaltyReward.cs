using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
public partial class LoyaltyReward : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("discount")]
    public double? Discount { get; set; }

    [Column("required_points")]
    public double? RequiredPoints { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("LoyaltyReward")] // [Many2one]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LoyaltyRewardCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DiscountLineProductId")]
    // [InverseProperty("LoyaltyRewardDiscountLineProduct")] // [Many2one]
    public virtual ProductProduct? DiscountLineProduct { get; set; }

    // [Many2one]
    [ForeignKey("DiscountProductCategoryId")]
    // [InverseProperty("LoyaltyReward")] // [Many2one]
    public virtual ProductCategory? DiscountProductCategory { get; set; }

    // [Many2one]
    [ForeignKey("DiscountProductTagId")]
    // [InverseProperty("LoyaltyRewardDiscountProductTag")] // [Many2one]
    public virtual ProductTag? DiscountProductTag { get; set; }


    // [Many2many]
    [NotMapped] // Many2many
    // [InverseProperty("Reward")] // Many2many
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    // [InverseProperty("LoyaltyReward")] // [Many2one]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("RewardProductId")]
    // [InverseProperty("LoyaltyRewardRewardProduct")] // [Many2one]
    public virtual ProductProduct? RewardProduct { get; set; }

    // [Many2one]
    [ForeignKey("RewardProductTagId")]
    // [InverseProperty("LoyaltyRewardRewardProductTag")] // [Many2one]
    public virtual ProductTag? RewardProductTag { get; set; }


    // [Many2many]
    //[NotMapped] // Many2many
    // [InverseProperty("SelectedReward")] // Many2many
    //public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizard { get; set; }


    // [Many2many]
    [NotMapped] // Many2many
    // [InverseProperty("Reward")] // Many2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LoyaltyRewardWriteU")] // [Many2one]
    public virtual ResUser? WriteU { get; set; }

    // [One2many]
    [ForeignKey("LoyaltyRewardId")]
    // [NotMapped] // One2many
    // [InverseProperty("LoyaltyReward")]  //[One2many]
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [One2many]
    [ForeignKey("LoyaltyRewardId")]
    // [NotMapped] // One2many
    // [InverseProperty("LoyaltyReward")]  //[One2many]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
