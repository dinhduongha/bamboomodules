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

[Table("res_country")]
//[Index("Code", Name = "res_country_code_uniq", IsUnique = true)]
//[Index("Name", Name = "res_country_name_uniq", IsUnique = true)]
public partial class ResCountry: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("address_view_id")]
    public Guid? AddressViewId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("phone_code")]
    public long? PhoneCode { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("name_position")]
    public string? NamePosition { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("vat_label", TypeName = "jsonb")]
    public string? VatLabel { get; set; }

    [Column("address_format")]
    public string? AddressFormat { get; set; }

    [Column("state_required")]
    public bool? StateRequired { get; set; }

    [Column("zip_required")]
    public bool? ZipRequired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AddressViewId")]
    //[InverseProperty("ResCountries")]
    [NotMapped]
    public virtual IrUiView? AddressView { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResCountryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("ResCountries")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCountryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE
    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTags { get; } = new List<AccountAccountTag>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplates { get; } = new List<AccountChartTemplate>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplates { get; } = new List<AccountFiscalPositionTemplate>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; } = new List<AccountFiscalPosition>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountReport> AccountReports { get; } = new List<AccountReport>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroups { get; } = new List<AccountTaxGroup>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxes { get; } = new List<AccountTax>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeCountries { get; } = new List<HrEmployee>();

    //[InverseProperty("CountryOfBirthNavigation")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeCountryOfBirthNavigations { get; } = new List<HrEmployee>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypes { get; } = new List<HrPayrollStructureType>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<MailGuest> MailGuests { get; } = new List<MailGuest>();

    //[InverseProperty("PartnerCountry")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    //[InverseProperty("CountryNavigation")]
    [NotMapped]
    public virtual ICollection<ResBank> ResBanks { get; } = new List<ResBank>();

    //[InverseProperty("AccountFiscalCountry")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<ResCountryState> ResCountryStates { get; } = new List<ResCountryState>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFields { get; } = new List<SnailmailLetterMissingRequiredField>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; } = new List<SnailmailLetter>();

    //[InverseProperty("Country")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitors { get; } = new List<WebsiteVisitor>();

    [ForeignKey("ResCountryId")]
    //[InverseProperty("ResCountries")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequests { get; } = new List<CrmIapLeadMiningRequest>();

    [ForeignKey("CountryId")]
    //[InverseProperty("Countries")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> Payments { get; } = new List<PaymentProvider>();

    [ForeignKey("ResCountryId")]
    //[InverseProperty("ResCountries")]
    [NotMapped]
    public virtual ICollection<ResCountryGroup> ResCountryGroups { get; } = new List<ResCountryGroup>();

}
