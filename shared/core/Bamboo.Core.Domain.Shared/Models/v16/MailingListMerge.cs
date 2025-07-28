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

[Table("mailing_list_merge")]
public partial class MailingListMerge: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("dest_list_id")]
    public Guid? DestListId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("merge_options")]
    public string? MergeOptions { get; set; }

    [Column("new_list_name")]
    public string? NewListName { get; set; }

    [Column("archive_src_lists")]
    public bool? ArchiveSrcLists { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingListMergeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DestListId")]
    //[InverseProperty("MailingListMergesNavigation")]
    [NotMapped]
    public virtual MailingList? DestList { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingListMergeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MailingListMergeId")]
    //[InverseProperty("MailingListMerges")]
    [NotMapped]
    public virtual ICollection<MailingList> MailingLists { get; set; } 
}
