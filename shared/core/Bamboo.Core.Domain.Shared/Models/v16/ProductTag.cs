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
//[Index("WebsiteId", Name = "product_tag__website_id_index")]
//[Index("Name", Name = "product_tag_name_uniq", IsUnique = true)]
public partial class ProductTag: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("visible_on_ecommerce")]
    public bool? VisibleOnEcommerce { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("DiscountProductTagId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DiscountProductTag")] // One2many
    public virtual ICollection<LoyaltyReward> LoyaltyRewardDiscountProductTag { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RewardProductTagId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RewardProductTag")] // One2many
    public virtual ICollection<LoyaltyReward> LoyaltyRewardRewardProductTag { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ProductTagId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ProductTag")] // One2many
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTagId")] //Many2many // Hidden
    // [InverseProperty("ProductTag")] //Many2many // Hidden
    public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTagId")] //Many2many // Hidden
    // [InverseProperty("ProductTagNavigation")] //Many2many // Hidden
    public virtual ICollection<DeliveryCarrier> DeliveryCarrierNavigation { get; set; }

    // [Many2many] // Hidden

    [NotMapped] //Many2many // Hidden // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("ProductTagId")] //Many2many // Hidden
    // [InverseProperty("ProductTag")] //Many2many // Hidden
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProductTagId")] //Many2many // Hidden
    // [InverseProperty("ProductTag")] //Many2many // Hidden
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }
}
