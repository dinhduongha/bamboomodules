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

[Table("coupon_share")]
public partial class CouponShare : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("coupon_id")]
    public Guid? CouponId { get; set; }

    [Column("program_id")]
    public Guid? ProgramId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("redirect")]
    public string? Redirect { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CouponId")]
    // [InverseProperty("CouponShare")] // [Many2one]
    public virtual LoyaltyCard? Coupon { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CouponShareCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    // [InverseProperty("CouponShare")] // [Many2one]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("CouponShare")] // [Many2one]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CouponShareWriteU")] // [Many2one]
    public virtual ResUser? WriteU { get; set; }
}
