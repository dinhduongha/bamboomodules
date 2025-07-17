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
/// <summary>
/// Mass Mailing Subscription Information
/// </summary>
//[Table("mailing_contact_list_rel")]
//[Index("ContactId", "ListId", Name = "mailing_contact_list_rel_unique_contact_list", IsUnique = true)]
public partial class MailingContactListRel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    /// <summary>
    /// Contact
    /// </summary>
    [Column("contact_id")]
    public Guid? ContactId { get; set; }

    /// <summary>
    /// Mailing List
    /// </summary>
    [Column("list_id")]
    public Guid ListId { get; set; }

    /// <summary>
    /// Created by
    /// </summary>
    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    /// <summary>
    /// Last Updated by
    /// </summary>
    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    /// <summary>
    /// Opt Out
    /// </summary>
    [Column("opt_out")]
    public bool? OptOut { get; set; }

    /// <summary>
    /// Unsubscription Date
    /// </summary>
    [Column("unsubscription_date", TypeName = "timestamp without time zone")]
    public DateTime? UnsubscriptionDate { get; set; }

    /// <summary>
    /// Created on
    /// </summary>
    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// Last Updated on
    /// </summary>
    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ContactId")]
    //[InverseProperty("MailingContactListRels")]
    public virtual MailingContact Contact { get; set; } = null!;

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingContactListRelCreateUs")]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ListId")]
    //[InverseProperty("MailingContactListRels")]
    public virtual MailingList List { get; set; } = null!;

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingContactListRelWriteUs")]
    public virtual ResUser? WriteU { get; set; }
}
