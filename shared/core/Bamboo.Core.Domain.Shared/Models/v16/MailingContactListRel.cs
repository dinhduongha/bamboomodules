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

[Table("mailing_contact_list_rel")]
//[Index("ContactId", "ListId", Name = "mailing_contact_list_rel_unique_contact_list", IsUnique = true)]
public partial class MailingContactListRel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("contact_id")]
    public Guid? ContactId { get; set; }

    [Column("list_id")]
    public Guid? ListId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("opt_out")]
    public bool? OptOut { get; set; }

    [Column("unsubscription_date", TypeName = "timestamp without time zone")]
    public DateTime? UnsubscriptionDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ContactId")]
    // [InverseProperty("MailingContactListRel")] //Many2one
    public virtual MailingContact? Contact { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailingContactListRelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ListId")]
    // [InverseProperty("MailingContactListRel")] //Many2one
    public virtual MailingList? List { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailingContactListRelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
