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

[Table("loyalty_rule")]
public partial class LoyaltyRule : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("program_id")]
    public Guid? ProgramId { get; set; }

    [Column("product_category_id")]
    public Guid? ProductCategoryId { get; set; }

    [Column("product_tag_id")]
    public Guid? ProductTagId { get; set; }

    [Column("minimum_qty")]
    public long? MinimumQty { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("reward_point_amount")]
    public double? RewardPointAmount { get; set; }

    [Column("promo_barcode")]
    public string? PromoBarcode { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("LoyaltyRule")] // [Many2one]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LoyaltyRuleCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProductCategoryId")]
    // [InverseProperty("LoyaltyRule")] // [Many2one]
    public virtual ProductCategory? ProductCategory { get; set; }

    // [Many2one]
    [ForeignKey("ProductTagId")]
    // [InverseProperty("LoyaltyRule")] // [Many2one]
    public virtual ProductTag? ProductTag { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    // [InverseProperty("LoyaltyRule")] // [Many2one]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("LoyaltyRule")] // [Many2one]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LoyaltyRuleWriteU")] // [Many2one]
    public virtual ResUser WriteU { get; set; }

    // [One2many]
    [ForeignKey("LoyaltyRuleId")]
    // [NotMapped] // One2many
    // [InverseProperty("LoyaltyRule")]  //[One2many]
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [One2many]
    [ForeignKey("LoyaltyRuleId")]
    // [NotMapped] // One2many
    // [InverseProperty("LoyaltyRule")]  //[One2many]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
