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

[Table("mail_alias_domain")]
//[Index("BounceAlias", "Name", Name = "mail_alias_domain_bounce_email_uniques", IsUnique = true)]
//[Index("CatchallAlias", "Name", Name = "mail_alias_domain_catchall_email_uniques", IsUnique = true)]
public partial class MailAliasDomain: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("bounce_alias")]
    public string? BounceAlias { get; set; }

    [Column("catchall_alias")]
    public string? CatchallAlias { get; set; }

    [Column("default_from")]
    public string? DefaultFrom { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailAliasDomainCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AliasDomainId")]
    [InverseProperty("AliasDomain")]
    public virtual ICollection<MailAlias> MailAlias { get; set; }

    // [One2many]
    [ForeignKey("RecordAliasDomainId")]
    [InverseProperty("RecordAliasDomain")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [ForeignKey("RecordAliasDomainId")]
    [InverseProperty("RecordAliasDomain")]
    public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many]
    [ForeignKey("AliasDomainId")]
    [InverseProperty("AliasDomain")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailAliasDomainWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
