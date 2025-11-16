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

[Table("account_fiscal_position")]
public partial class AccountFiscalPosition : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("country_group_id")]
    public Guid? CountryGroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("zip_from")]
    public string? ZipFrom { get; set; }

    [Column("zip_to")]
    public string? ZipTo { get; set; }

    [Column("foreign_vat")]
    public string? ForeignVat { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField] // Note
    [Column("note", TypeName = "jsonb")]
    public JsonElement? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("auto_apply")]
    public bool? AutoApply { get; set; }

    [Column("vat_required")]
    public bool? VatRequired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Position")] // One2many
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Position")] // One2many
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTax { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FiscalPosition")] // One2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ForeignVatFiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ForeignVatFiscalPosition")] // One2many
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValue { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryGroupId")]
    public virtual ResCountryGroup? CountryGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // CONFLICK-V19
    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DefaultFiscalPositionId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("DefaultFiscalPosition")] // One2many
    // public virtual ICollection<PosConfig> PosConfigDefaultFiscalPosition { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TakeawayFpId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TakeawayFp")] // One2many
    public virtual ICollection<PosConfig> PosConfigTakeawayFp { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FiscalPosition")] // One2many
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FiscalPosition")] // One2many
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PosDefaultFiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosDefaultFiscalPosition")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettingsNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FiscalPosition")] // One2many
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountFiscalPositionId")] //Many2many // Hidden
    // [InverseProperty("AccountFiscalPosition")] //Many2many // Hidden
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountFiscalPositionId")] //Many2many // Hidden
    // [InverseProperty("AccountFiscalPosition")] //Many2many // Hidden
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResCountryState) is commented out
    // [ForeignKey("AccountFiscalPositionId")] // Many2many // Normal
    // [InverseProperty("AccountFiscalPosition")] // Many2many // Normal
    public virtual ICollection<ResCountryState> ResCountryState { get; set; }
}
