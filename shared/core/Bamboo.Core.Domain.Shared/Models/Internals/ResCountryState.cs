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
    [ForeignKey("CountryId")]
    // [InverseProperty("ResCountryState")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResCountryStateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("StateId")]
    [InverseProperty("State")]
    public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many]
    [ForeignKey("PrivateStateId")]
    [InverseProperty("PrivateState")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [ForeignKey("PartnerStateId")]
    [InverseProperty("PartnerState")]
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many]
    [ForeignKey("State")]
    [InverseProperty("StateNavigation")]
    public virtual ICollection<ResBank> ResBank { get; set; }

    // [One2many]
    [ForeignKey("StateId")]
    [InverseProperty("State")]
    public virtual ICollection<ResCity> ResCity { get; set; }

    // [One2many]
    [ForeignKey("StateId")]
    [InverseProperty("State")]
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many]
    [ForeignKey("StateId")]
    [InverseProperty("StateNavigation")]
    public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many]
    [ForeignKey("StateId")]
    [InverseProperty("State")]
    public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResCountryStateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")]
    // [InverseProperty("ResCountryState")]
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPosition { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")]
    // [InverseProperty("ResCountryState")]
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("StateId")]
    // [InverseProperty("State")]
    // public virtual ICollection<DeliveryCarrier> Carrier { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")]
    // [InverseProperty("ResCountryState")]
    // public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequest { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")]
    // [InverseProperty("ResCountryState")]
    // public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }
}
