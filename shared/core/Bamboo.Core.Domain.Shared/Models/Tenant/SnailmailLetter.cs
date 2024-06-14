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

[Table("snailmail_letter")]
public partial class SnailmailLetter: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("report_template")]
    public Guid? ReportTemplate { get; set; }

    [Column("attachment_id")]
    public Guid? AttachmentId { get; set; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("state_id")]
    public long? StateId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("error_code")]
    public string? ErrorCode { get; set; }

    [Column("info_msg")]
    public string? InfoMsg { get; set; }

    [Column("street")]
    public string? Street { get; set; }

    [Column("street2")]
    public string? Street2 { get; set; }

    [Column("zip")]
    public string? Zip { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("color")]
    public bool? Color { get; set; }

    [Column("cover")]
    public bool? Cover { get; set; }

    [Column("duplex")]
    public bool? Duplex { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AttachmentId")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual IrAttachment? Attachment { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SnailmailLetterCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageId")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual MailMessage? Message { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ReportTemplate")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual IrActReportXml? ReportTemplateNavigation { get; set; }

    [ForeignKey("StateId")]
    //[InverseProperty("SnailmailLetters")]
    [NotMapped]
    public virtual ResCountryState? StateNavigation { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("SnailmailLetterUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SnailmailLetterWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Letter")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotifications { get; } = new List<MailNotification>();

    //[InverseProperty("Letter")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFields { get; } = new List<SnailmailLetterMissingRequiredField>();


}
