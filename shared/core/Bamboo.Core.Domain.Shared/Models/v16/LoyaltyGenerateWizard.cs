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

[Table("loyalty_generate_wizard")]
public partial class LoyaltyGenerateWizard : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("program_id")]
    public Guid? ProgramId { get; set; }

    [Column("coupon_qty")]
    public long? CouponQty { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [Column("valid_until")]
    public DateTime? ValidUntil { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("points_granted")]
    public double? PointsGranted { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LoyaltyGenerateWizardCreateU")] // [Many2one]
    public virtual ResUser? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ProgramId")]
    // [InverseProperty("LoyaltyGenerateWizard")] // [Many2one]
    public virtual LoyaltyProgram? Program { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LoyaltyGenerateWizardWriteU")] // [Many2one]
    public virtual ResUser? WriteU { get; set; }

    // [One2many]
    [ForeignKey("LoyaltyGenerateWizardId")]
    // [NotMapped] // One2many
    // [InverseProperty("LoyaltyGenerateWizard")]  //[One2many]
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many]
    [ForeignKey("LoyaltyGenerateWizardId")]
    // [NotMapped] // One2many
    // [InverseProperty("LoyaltyGenerateWizard")]  //[One2many]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategory { get; set; }
}
