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
public partial class MailAliasDomain: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailAliasDomainCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("AliasDomain")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliases { get; set; } 

    //[InverseProperty("RecordAliasDomain")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } 

    //[InverseProperty("RecordAliasDomain")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; set; } 

    //[InverseProperty("AliasDomain")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailAliasDomainWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
