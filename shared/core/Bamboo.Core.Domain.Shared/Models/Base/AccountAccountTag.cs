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

[Table("account_account_tag")]
public partial class AccountAccountTag: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("applicability")]
    public string? Applicability { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("tax_negate")]
    public bool? TaxNegate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAccountTagCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAccountTagWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountAccountTagId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplates { get; } = new List<AccountAccountTemplate>();

    [ForeignKey("AccountAccountTagId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } = new List<AccountAccount>();

    [ForeignKey("AccountAccountTagId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    [ForeignKey("AccountAccountTagId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplates { get; } = new List<AccountTaxRepartitionLineTemplate>();

    [ForeignKey("AccountAccountTagId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; } = new List<AccountTaxRepartitionLine>();

    [ForeignKey("AccountAccountTagId")]
    //[InverseProperty("AccountAccountTags")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();
}
