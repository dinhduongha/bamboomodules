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

[Table("account_fiscal_position")]
public partial class AccountFiscalPosition: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("country_group_id")]
    public Guid? CountryGroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("zip_from")]
    public string? ZipFrom { get; set; }

    [Column("zip_to")]
    public string? ZipTo { get; set; }

    [Column("foreign_vat")]
    public string? ForeignVat { get; set; }

    [JsonField]
    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

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
    [ForeignKey("PositionId")]
    [InverseProperty("Position")]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccount { get; set; }

    // [One2many]
    [ForeignKey("PositionId")]
    [InverseProperty("Position")]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTax { get; set; }

    // [One2many]
    [ForeignKey("FiscalPositionId")]
    [InverseProperty("FiscalPosition")]
    public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many]
    [ForeignKey("ForeignVatFiscalPositionId")]
    [InverseProperty("ForeignVatFiscalPosition")]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValue { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountFiscalPosition")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountFiscalPosition")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CountryGroupId")]
    // [InverseProperty("AccountFiscalPosition")] //Many2one
    public virtual ResCountryGroup? CountryGroup { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountFiscalPositionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("DefaultFiscalPositionId")]
    [InverseProperty("DefaultFiscalPosition")]
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // [One2many]
    [ForeignKey("FiscalPositionId")]
    [InverseProperty("FiscalPosition")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("FiscalPositionId")]
    [InverseProperty("FiscalPosition")]
    public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many]
    [ForeignKey("PosDefaultFiscalPositionId")]
    [InverseProperty("PosDefaultFiscalPosition")]
    public virtual ICollection<ResConfigSettings> ResConfigSettingsNavigation { get; set; }

    // [One2many]
    [ForeignKey("FiscalPositionId")]
    [InverseProperty("FiscalPosition")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountFiscalPositionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountFiscalPositionId")]
    // [InverseProperty("AccountFiscalPosition")]
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountFiscalPositionId")]
    // [InverseProperty("AccountFiscalPosition")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountFiscalPositionId")] //Many2many
    // [InverseProperty("AccountFiscalPosition")] //Many2many
    public virtual ICollection<ResCountryState> ResCountryState { get; set; }
}
