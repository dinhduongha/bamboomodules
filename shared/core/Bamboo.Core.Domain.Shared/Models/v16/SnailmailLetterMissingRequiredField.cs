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

[Table("snailmail_letter_missing_required_fields")]
public partial class SnailmailLetterMissingRequiredField: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }
    
    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("letter_id")]
    public Guid? LetterId { get; set; }

    [Column("state_id")]
    public Guid? StateId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("street")]
    public string? Street { get; set; }

    [Column("street2")]
    public string? Street2 { get; set; }

    [Column("zip")]
    public string? Zip { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("SnailmailLetterMissingRequiredFields")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SnailmailLetterMissingRequiredFieldCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LetterId")]
    //[InverseProperty("SnailmailLetterMissingRequiredFields")]
    [NotMapped]
    public virtual SnailmailLetter? Letter { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("SnailmailLetterMissingRequiredFields")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("StateId")]
    //[InverseProperty("SnailmailLetterMissingRequiredFields")]
    [NotMapped]
    public virtual ResCountryState? State { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SnailmailLetterMissingRequiredFieldWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
