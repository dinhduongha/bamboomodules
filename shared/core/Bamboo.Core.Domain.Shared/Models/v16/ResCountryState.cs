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

[Module("base")]
[Table("res_country_state")]
//[Index("CountryId", "Code", Name = "res_country_state_name_code_uniq", IsUnique = true)]
public partial class ResCountryState: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("ResCountryStates")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResCountryStateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResCountryStateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE
    //[InverseProperty("State")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } 

    //[InverseProperty("PrivateState")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } 

    //[InverseProperty("PartnerState")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 

    //[InverseProperty("StateNavigation")]
    [NotMapped]
    public virtual ICollection<ResBank> ResBanks { get; set; } 

    //[InverseProperty("State")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 

    //[InverseProperty("State")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFields { get; set; } 

    //[InverseProperty("StateNavigation")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } 

    [ForeignKey("ResCountryStateId")]
    //[InverseProperty("ResCountryStates")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositions { get; set; } 

    [ForeignKey("StateId")]
    //[InverseProperty("States")]
    [NotMapped]
    public virtual ICollection<DeliveryCarrier> Carriers { get; set; } 

    [ForeignKey("ResCountryStateId")]
    //[InverseProperty("ResCountryStates")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplates { get; set; } 


    [ForeignKey("ResCountryStateId")]
    //[InverseProperty("ResCountryStates")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequests { get; set; } 
}
