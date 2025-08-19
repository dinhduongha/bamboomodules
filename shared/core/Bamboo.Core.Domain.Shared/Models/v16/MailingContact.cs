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

[Table("mailing_contact")]
public partial class MailingContact: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("title_id")]
    public Guid? TitleId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("company_name")]
    public string? CompanyName { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("MailingContact")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailingContactCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ContactId")]
    [InverseProperty("Contact")]
    public virtual ICollection<MailingContactListRel> MailingContactListRel { get; set; }

    // [One2many]
    [ForeignKey("ContactId")]
    [InverseProperty("Contact")]
    public virtual ICollection<MailingSubscription> MailingSubscription { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MailingContact")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("TitleId")]
    // [InverseProperty("MailingContact")] //Many2one
    public virtual ResPartnerTitle? Title { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailingContactWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MailingContactId")]
    // [InverseProperty("MailingContact")]
    public virtual ICollection<MailingContactToList> MailingContactToList { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailingContactId")] //Many2many
    // [InverseProperty("MailingContact")] //Many2many
    public virtual ICollection<ResPartnerCategory> ResPartnerCategory { get; set; }
}
