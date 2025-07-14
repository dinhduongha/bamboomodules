using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("mail_canned_response")]
public partial class MailCannedResponse: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("source")]
    public string? Source { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("substitution")]
    public string? Substitution { get; set; }

    [Column("is_shared")]
    public bool? IsShared { get; set; }

    [Column("last_used", TypeName = "timestamp without time zone")]
    public DateTime? LastUsed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailCannedResponseCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailCannedResponseWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MailCannedResponseId")]
    //[InverseProperty("MailCannedResponses")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; set; } = new List<ResGroup>();
}
