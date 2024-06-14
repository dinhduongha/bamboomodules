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
public partial class AccountFiscalPosition: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("country_group_id")]
    public long? CountryGroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("zip_from")]
    public string? ZipFrom { get; set; }

    [Column("zip_to")]
    public string? ZipTo { get; set; }

    [Column("foreign_vat")]
    public string? ForeignVat { get; set; }

    [Column("note", TypeName = "jsonb")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("auto_apply")]
    public bool? AutoApply { get; set; }

    [Column("vat_required")]
    public bool? VatRequired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountFiscalPositions")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("AccountFiscalPositions")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CountryGroupId")]
    //[InverseProperty("AccountFiscalPositions")]
    [NotMapped]
    public virtual ResCountryGroup? CountryGroup { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountFiscalPositionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountFiscalPositionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Position")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccounts { get; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("Position")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxes { get; } = new List<AccountFiscalPositionTax>();

    //[InverseProperty("FiscalPosition")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("ForeignVatFiscalPosition")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValues { get; } = new List<AccountReportExternalValue>();

    //[InverseProperty("DefaultFiscalPosition")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigsNavigation { get; } = new List<PosConfig>();

    //[InverseProperty("FiscalPosition")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    //[InverseProperty("FiscalPosition")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    //[InverseProperty("PosDefaultFiscalPosition")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingsNavigation { get; } = new List<ResConfigSetting>();

    //[InverseProperty("FiscalPosition")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    [ForeignKey("AccountFiscalPositionId")]
    //[InverseProperty("AccountFiscalPositions")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    [ForeignKey("AccountFiscalPositionId")]
    //[InverseProperty("AccountFiscalPositions")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; } = new List<ResConfigSetting>();

    [ForeignKey("AccountFiscalPositionId")]
    //[InverseProperty("AccountFiscalPositions")]
    [NotMapped]
    public virtual ICollection<ResCountryState> ResCountryStates { get; } = new List<ResCountryState>();
}
