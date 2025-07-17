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
public partial class MailingContact: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("title_id")]
    public Guid? TitleId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("MailingContacts")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingContactCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("...")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    //[InverseProperty("Contact")]
    [NotMapped]
    public virtual ICollection<MailingSubscription> MailingSubscriptions { get; set; } = new List<MailingSubscription>();

    [ForeignKey("TitleId")]
    //[InverseProperty("MailingContacts")]
    [NotMapped]
    public virtual ResPartnerTitle? Title { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingContactWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MailingContactId")]
    //[InverseProperty("MailingContacts")]
    [NotMapped]
    public virtual ICollection<MailingContactToList> MailingContactToLists { get; set; } = new List<MailingContactToList>();

    [ForeignKey("MailingContactId")]
    //[InverseProperty("MailingContacts")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategories { get; set; } = new List<ResPartnerCategory>();
}
