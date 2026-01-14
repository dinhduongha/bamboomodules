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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField(IsSparse = false)] // VatLabel
    [Column("vat_label", TypeName = "jsonb")]
    public StringDictionary? VatLabel { get; set; }

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
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountAccountTag) is commented out
    // public virtual ICollection<AccountAccountTag> AccountAccountTag { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountFiscalPosition) is commented out
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountReport) is commented out
    // public virtual ICollection<AccountReport> AccountReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountTax) is commented out
    // public virtual ICollection<AccountTax> AccountTax { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (AccountTaxGroup) is commented out
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroup { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AddressViewId")]
    public virtual IrUiView? AddressView { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (CrmLead) is commented out
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrencyId")]
    public virtual ResCurrency? Currency { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (DiscussChannel) is commented out
    // public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (EventEvent) is commented out
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrContractType) is commented out
    // public virtual ICollection<HrContractType> HrContractType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployeeCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryOfBirth")]
    // [NotMapped] // One2many 
    // [InverseProperty("CountryOfBirthNavigation")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployeeCountryOfBirthNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("PrivateCountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PrivateCountry")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployeePrivateCountry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrPayrollStructureType) is commented out
    // public virtual ICollection<HrPayrollStructureType> HrPayrollStructureType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (HrWorkEntryType) is commented out
    // public virtual ICollection<HrWorkEntryType> HrWorkEntryType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (LinkTrackerClick) is commented out
    // public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (MailGuest) is commented out
    // public virtual ICollection<MailGuest> MailGuest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (MailingContact) is commented out
    // public virtual ICollection<MailingContact> MailingContact { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("PartnerCountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerCountry")] // One2many // Peer relationship (PaymentTransaction) is commented out
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryOfOrigin")]
    // [NotMapped] // One2many 
    // [InverseProperty("CountryOfOriginNavigation")] // One2many // Peer relationship (ProductTemplate) is commented out
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("Country")]
    // [NotMapped] // One2many 
    // [InverseProperty("CountryNavigation")] // One2many // Peer relationship (ResBank) is commented out
    // public virtual ICollection<ResBank> ResBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (ResCity) is commented out
    // public virtual ICollection<ResCity> ResCity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("AccountFiscalCountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AccountFiscalCountry")] // One2many
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many
    // public virtual ICollection<ResCountryState> ResCountryState { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (SnailmailLetterMissingRequiredFields) is commented out
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountry'
    // [One2many] [ForeignKey("CountryId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Country")] // One2many // Peer relationship (WebsiteVisitor) is commented out
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitor { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")] //Many2many // Hidden
    // [InverseProperty("Country")] //Many2many // Hidden
    public virtual ICollection<DeliveryCarrier> Carrier { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")] //Many2many // Hidden
    // [InverseProperty("Country")] //Many2many // Hidden
    public virtual ICollection<ImLivechatChannelRule> Channel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryId")] //Many2many // Hidden
    // [InverseProperty("ResCountry")] //Many2many // Hidden
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequest { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryId")] //Many2many // Hidden
    // [InverseProperty("ResCountry")] //Many2many // Hidden
    public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")] //Many2many // Hidden
    // [InverseProperty("Country")] //Many2many // Hidden
    public virtual ICollection<IrModuleModule> Module { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("CountryId")] //Many2many // Hidden
    // [InverseProperty("Country")] //Many2many // Hidden
    public virtual ICollection<PaymentProvider> Payment { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryId")] //Many2many // Hidden
    // [InverseProperty("ResCountry")] //Many2many // Hidden
    public virtual ICollection<PaymentMethod> PaymentMethod { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ResCountryId")] // Many2many // Normal
    // [InverseProperty("ResCountry")] // Many2many // Normal
    public virtual ICollection<ResCountryGroup> ResCountryGroup { get; set; }
}
