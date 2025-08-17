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
public partial class SnailmailLetter: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("report_template")]
    public Guid? ReportTemplate { get; set; }

    [Column("attachment_id")]
    public Guid? AttachmentId { get; set; }

    [Column("message_id")]
    public Guid? MessageId { get; set; }

    [Column("state_id")]
    public Guid? StateId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AttachmentId")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual IrAttachment? Attachment { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SnailmailLetterCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("LetterId")]
    [InverseProperty("Letter")]
    public virtual ICollection<MailNotification> MailNotification { get; set; }

    // [Many2one]
    [ForeignKey("MessageId")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual MailMessage? Message { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("ReportTemplate")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual IrActReportXml? ReportTemplateNavigation { get; set; }

    // [One2many]
    [ForeignKey("LetterId")]
    [InverseProperty("Letter")]
    public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [Many2one]
    [ForeignKey("StateId")]
    // [InverseProperty("SnailmailLetter")] //Many2one
    public virtual ResCountryState? StateNavigation { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("SnailmailLetterUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SnailmailLetterWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
