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
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailingListId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailingList")] // One2many
    public virtual ICollection<MailingContactToList> MailingContactToList { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("DestListId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DestList")] // One2many
    public virtual ICollection<MailingListMerge> MailingListMergeNavigation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ListId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("List")] // One2many
    public virtual ICollection<MailingSubscription> MailingSubscription { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("NewsletterId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("Newsletter")] // One2many
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingListId")] //Many2many // Hidden
    // [InverseProperty("MailingList")] //Many2many // Hidden
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingListId")] //Many2many // Hidden
    // [InverseProperty("MailingList")] //Many2many // Hidden
    public virtual ICollection<MailingContactImport> MailingContactImport { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingListId")] //Many2many // Hidden
    // [InverseProperty("MailingList")] //Many2many // Hidden
    public virtual ICollection<MailingListMerge> MailingListMerge { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MailingListId")] // Many2many // Normal
    // [InverseProperty("MailingList")] // Many2many // Normal
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }
}
