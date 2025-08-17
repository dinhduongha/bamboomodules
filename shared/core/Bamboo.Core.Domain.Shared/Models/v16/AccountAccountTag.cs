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
public partial class AccountAccountTag: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("color")]
    public long? Color { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("applicability")]
    public string? Applicability { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("tax_negate")]
    public bool? TaxNegate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("AccountAccountTag")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAccountTagCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAccountTagWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")]
    // [InverseProperty("AccountAccountTag")]
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")]
    // [InverseProperty("AccountAccountTag")]
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")]
    // [InverseProperty("AccountAccountTag")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")]
    // [InverseProperty("AccountAccountTag")]
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")]
    // [InverseProperty("AccountAccountTag")]
    // public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplate { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")]
    // [InverseProperty("AccountAccountTag")]
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }
}
