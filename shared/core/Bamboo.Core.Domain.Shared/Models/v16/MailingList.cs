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
public partial class MailingList: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_public")]
    public bool? IsPublic { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailingListCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ListId")]
    [InverseProperty("List")]
    public virtual ICollection<MailingContactListRel> MailingContactListRel { get; set; }

    // [One2many]
    [ForeignKey("MailingListId")]
    [InverseProperty("MailingList")]
    public virtual ICollection<MailingContactToList> MailingContactToList { get; set; }

    // [One2many]
    [ForeignKey("DestListId")]
    [InverseProperty("DestList")]
    public virtual ICollection<MailingListMerge> MailingListMergeNavigation { get; set; }

    // [One2many]
    [ForeignKey("ListId")]
    [InverseProperty("List")]
    public virtual ICollection<MailingSubscription> MailingSubscription { get; set; }

    // [One2many]
    [ForeignKey("NewsletterId")]
    [InverseProperty("Newsletter")]
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailingListWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingListId")]
    // [InverseProperty("MailingList")]
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingListId")]
    // [InverseProperty("MailingList")]
    public virtual ICollection<MailingContactImport> MailingContactImport { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingListId")]
    // [InverseProperty("MailingList")]
    public virtual ICollection<MailingListMerge> MailingListMerge { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailingListId")] //Many2many
    // [InverseProperty("MailingList")] //Many2many
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }
}
