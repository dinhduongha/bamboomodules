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
public partial class ResCountry: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("address_view_id")]
    public Guid? AddressViewId { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("phone_code")]
    public long? PhoneCode { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("name_position")]
    public string? NamePosition { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("vat_label", TypeName = "jsonb")]
    public string? VatLabel { get; set; }

    [Column("address_format")]
    public string? AddressFormat { get; set; }

    [Column("state_required")]
    public bool? StateRequired { get; set; }

    [Column("zip_required")]
    public bool? ZipRequired { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("enforce_cities")]
    public bool? EnforceCities { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountReport> AccountReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroup { get; set; }

    // [Many2one]
    [ForeignKey("AddressViewId")]
    // [InverseProperty("ResCountry")] //Many2one
    public virtual IrUiView? AddressView { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResCountryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("ResCountry")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<HrContractType> HrContractType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<HrEmployee> HrEmployeeCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryOfBirth")]
    // [InverseProperty("CountryOfBirthNavigation")]
    // public virtual ICollection<HrEmployee> HrEmployeeCountryOfBirthNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("PrivateCountryId")]
    // [InverseProperty("PrivateCountry")]
    // public virtual ICollection<HrEmployee> HrEmployeePrivateCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<HrPayrollStructureType> HrPayrollStructureType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<HrWorkEntryType> HrWorkEntryType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<MailGuest> MailGuest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<MailingContact> MailingContact { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("PartnerCountryId")]
    // [InverseProperty("PartnerCountry")]
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryOfOrigin")]
    // [InverseProperty("CountryOfOriginNavigation")]
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("Country")]
    // [InverseProperty("CountryNavigation")]
    // public virtual ICollection<ResBank> ResBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<ResCity> ResCity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("AccountFiscalCountryId")]
    // [InverseProperty("AccountFiscalCountry")]
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<ResCountryState> ResCountryState { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitor { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResCountryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<DeliveryCarrier> Carrier { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<ImLivechatChannelRule> Channel { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryId")]
    // [InverseProperty("ResCountry")]
    // public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequest { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryId")]
    // [InverseProperty("ResCountry")]
    // public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<IrModuleModule> Module { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")]
    // [InverseProperty("Country")]
    // public virtual ICollection<PaymentProvider> Payment { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryId")]
    // [InverseProperty("ResCountry")]
    // public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ResCountryId")] //Many2many
    // [InverseProperty("ResCountry")] //Many2many
    public virtual ICollection<ResCountryGroup> ResCountryGroup { get; set; }
}
