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

[Table("loyalty_program")]
//[Index("WebsiteId", Name = "loyalty_program_website_id_index")]
public partial class LoyaltyProgram: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("max_usage")]
    public long? MaxUsage { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("program_type")]
    public string? ProgramType { get; set; }

    [Column("applies_on")]
    public string? AppliesOn { get; set; }

    [Column("trigger")]
    public string? Trigger { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("portal_point_name", TypeName = "jsonb")]
    public string? PortalPointName { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("limit_usage")]
    public bool? LimitUsage { get; set; }

    [Column("portal_visible")]
    public bool? PortalVisible { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("pos_ok")]
    public bool? PosOk { get; set; }

    [Column("sale_ok")]
    public bool? SaleOk { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("ecommerce_ok")]
    public bool? EcommerceOk { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("LoyaltyProgram")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [One2many]
    [ForeignKey("ProgramId")]
    [InverseProperty("Program")]
    public virtual ICollection<CouponShare> CouponShare { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LoyaltyProgramCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("LoyaltyProgram")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [One2many]
    [ForeignKey("ProgramId")]
    [InverseProperty("Program")]
    public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many]
    [ForeignKey("ProgramId")]
    [InverseProperty("Program")]
    public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizard { get; set; }

    // [One2many]
    [ForeignKey("ProgramId")]
    [InverseProperty("Program")]
    public virtual ICollection<LoyaltyMail> LoyaltyMail { get; set; }

    // [One2many]
    [ForeignKey("ProgramId")]
    [InverseProperty("Program")]
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [One2many]
    [ForeignKey("ProgramId")]
    [InverseProperty("Program")]
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("LoyaltyProgram")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LoyaltyProgramWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("LoyaltyProgramId")] //Many2many
    // [InverseProperty("LoyaltyProgram")] //Many2many
    public virtual ICollection<PosConfig> PosConfig { get; set; }
}
