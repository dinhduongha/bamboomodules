using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("loyalty_program")]
//[Index("WebsiteId", Name = "loyalty_program__website_id_index")]
public partial class LoyaltyProgram : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // PortalPointName
    [Column("portal_point_name", TypeName = "jsonb")]
    public StringDictionary? PortalPointName { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgramId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Program")] // One2many
    public virtual ICollection<CouponShare> CouponShare { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgramId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Program")] // One2many
    public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgramId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Program")] // One2many
    public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgramId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Program")] // One2many
    public virtual ICollection<LoyaltyMail> LoyaltyMail { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgramId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Program")] // One2many
    public virtual ICollection<LoyaltyReward> LoyaltyReward { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProgramId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Program")] // One2many
    public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("LoyaltyProgramId")] // Many2many // Normal
    // [InverseProperty("LoyaltyProgram")] // Many2many // Normal
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("LoyaltyProgramId")] // Many2many // Normal
    // [InverseProperty("LoyaltyProgram")] // Many2many // Normal
    public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }
}
