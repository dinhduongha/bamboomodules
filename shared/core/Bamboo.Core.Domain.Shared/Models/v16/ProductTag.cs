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

[Table("product_tag")]
//[Index("Name", Name = "product_tag_name_uniq", IsUnique = true)]
//[Index("WebsiteId", Name = "product_tag_website_id_index")]
public partial class ProductTag: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("ribbon_id")]
    public Guid? RibbonId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProductTagCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("DiscountProductTagId")]
    [InverseProperty("DiscountProductTag")]
    public virtual ICollection<LoyaltyReward> LoyaltyRewardDiscountProductTag { get; set; }

    // [One2many]
    [ForeignKey("RewardProductTagId")]
    [InverseProperty("RewardProductTag")]
    public virtual ICollection<LoyaltyReward> LoyaltyRewardRewardProductTag { get; set; }

    // [One2many]
    [ForeignKey("ProductTagId")]
    [InverseProperty("ProductTag")]
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [ForeignKey("RibbonId")]
    // [InverseProperty("ProductTag")] //Many2one
    public virtual ProductRibbon? Ribbon { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("ProductTag")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProductTagWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTagId")]
    // [InverseProperty("ProductTag")]
    // public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTagId")]
    // [InverseProperty("ProductTag")]
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }
}
