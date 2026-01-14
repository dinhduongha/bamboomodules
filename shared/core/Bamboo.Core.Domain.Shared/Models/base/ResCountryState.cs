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

[Table("res_country_state")]
//[Index("CountryId", "Code", Name = "res_country_state_name_code_uniq", IsUnique = true)]
public partial class ResCountryState: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("StateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("State")] // One2many // Peer relationship (CrmLead) is commented out
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("PrivateStateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PrivateState")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("PartnerStateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerState")] // One2many // Peer relationship (PaymentTransaction) is commented out
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("State")]
    // [NotMapped] // One2many 
    // [InverseProperty("StateNavigation")] // One2many // Peer relationship (ResBank) is commented out
    // public virtual ICollection<ResBank> ResBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("StateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("State")] // One2many // Peer relationship (ResCity) is commented out
    // public virtual ICollection<ResCity> ResCity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("StateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("State")] // One2many
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("StateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("StateNavigation")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("StateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("State")] // One2many // Peer relationship (SnailmailLetterMissingRequiredFields) is commented out
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")] //Many2many // Hidden
    // [InverseProperty("ResCountryState")] //Many2many // Hidden
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StateId")] //Many2many // Hidden
    // [InverseProperty("State")] //Many2many // Hidden
    public virtual ICollection<DeliveryCarrier> Carrier { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")] //Many2many // Hidden
    // [InverseProperty("ResCountryState")] //Many2many // Hidden
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequest { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")] //Many2many // Hidden
    // [InverseProperty("ResCountryState")] //Many2many // Hidden
    public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }
}
