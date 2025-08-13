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

[Table("sale_order_coupon_points")]
//[Index("OrderId", "CouponId", Name = "sale_order_coupon_points_order_coupon_unique", IsUnique = true)]
public partial class SaleOrderCouponPoint: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("coupon_id")]
    public Guid? CouponId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("points")]
    public double? Points { get; set; }

    [ForeignKey("CouponId")]
    //[InverseProperty("SaleOrderCouponPoints")] //Many2One
    public virtual LoyaltyCard? Coupon { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SaleOrderCouponPointCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("SaleOrderCouponPoints")] //Many2One
    public virtual SaleOrder? Order { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SaleOrderCouponPointWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
