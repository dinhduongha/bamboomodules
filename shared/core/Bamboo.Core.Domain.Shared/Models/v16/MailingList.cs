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

[Table("mailing_list")]
public partial class MailingList: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_public")]
    public bool? IsPublic { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingListCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("MailingList")]
    [NotMapped]
    public virtual ICollection<MailingContactToList> MailingContactToLists { get; set; } 

    //[InverseProperty("DestList")]
    [NotMapped]
    public virtual ICollection<MailingListMerge> MailingListMergesNavigation { get; set; } 

    //[InverseProperty("List")]
    [NotMapped]
    public virtual ICollection<MailingSubscription> MailingSubscriptions { get; set; } 

    //[InverseProperty("Newsletter")]
    [NotMapped]
    public virtual ICollection<Website> Websites { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingListWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MailingListId")]
    //[InverseProperty("MailingLists")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } 

    [ForeignKey("MailingListId")]
    //[InverseProperty("MailingLists")]
    [NotMapped]
    public virtual ICollection<MailingContactImport> MailingContactImports { get; set; } 

    [ForeignKey("MailingListId")]
    //[InverseProperty("MailingLists")]
    [NotMapped]
    public virtual ICollection<MailingListMerge> MailingListMerges { get; set; } 

    [ForeignKey("MailingListId")]
    //[InverseProperty("MailingLists")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MailingMailings { get; set; } 
}
