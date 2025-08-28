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

[Table("loyalty_card")]
//[Index("PartnerId", Name = "loyalty_card__partner_id_index")]
//[Index("Code", Name = "loyalty_card_card_code_unique", IsUnique = true)]
public partial class LoyaltyCard: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("expiration_date")]
    public DateTime? ExpirationDate { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("points")]
    public double? Points { get; set; }

    [Column("source_pos_order_id")]
    public Guid? SourcePosOrderId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CouponId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Coupon")] // One2many
    public virtual ICollection<CouponShare> CouponShare { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CardId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Card")] // One2many
    public virtual ICollection<LoyaltyCardUpdateBalance> LoyaltyCardUpdateBalance { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CardId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Card")] // One2many
    public virtual ICollection<LoyaltyHistory> LoyaltyHistory { get; set; }

    // [Many2one]
    [ForeignKey("OrderId")]
    public virtual SaleOrder? Order { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CouponId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Coupon")] // One2many
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    public virtual LoyaltyProgram? Program { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CouponId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Coupon")] // One2many
    public virtual ICollection<SaleOrderCouponPoints> SaleOrderCouponPoints { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("CouponId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Coupon")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("SourcePosOrderId")]
    public virtual PosOrder? SourcePosOrder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("LoyaltyCardId")] //Many2many // Hidden
    // [InverseProperty("LoyaltyCardNavigation")] //Many2many // Hidden
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }
}
