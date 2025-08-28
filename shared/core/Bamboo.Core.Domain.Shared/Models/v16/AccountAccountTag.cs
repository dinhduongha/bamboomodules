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
//[Index("Name", "Applicability", "CountryId", Name = "account_account_tag_name_uniq", IsUnique = true)]
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

    [Column("applicability")]
    public string? Applicability { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

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
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden

    [NotMapped] //Many2many // Hidden // Peer relationship (AccountAccount) is commented out
    // [ForeignKey("AccountAccountTagId")] //Many2many // Hidden
    // [InverseProperty("AccountAccountTag")] //Many2many // Hidden
    public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")] //Many2many // Hidden
    // [InverseProperty("AccountAccountTag")] //Many2many // Hidden
    public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")] //Many2many // Hidden
    // [InverseProperty("AccountAccountTag")] //Many2many // Hidden
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLine { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAccountTagId")] //Many2many // Hidden
    // [InverseProperty("AccountAccountTag")] //Many2many // Hidden
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }
}
