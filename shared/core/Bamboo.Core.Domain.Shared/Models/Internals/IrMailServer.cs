using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("ir_mail_server")]
//[Index("Name", Name = "ir_mail_server__name_index")]
public partial class IrMailServer: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("smtp_port")]
    public long? SmtpPort { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("from_filter")]
    public string? FromFilter { get; set; }

    [Column("smtp_host")]
    public string? SmtpHost { get; set; }

    [Column("smtp_authentication")]
    public string? SmtpAuthentication { get; set; }

    [Column("smtp_user")]
    public string? SmtpUser { get; set; }

    [Column("smtp_pass")]
    public string? SmtpPass { get; set; }

    [Column("smtp_encryption")]
    public string? SmtpEncryption { get; set; }

    [Column("smtp_debug")]
    public bool? SmtpDebug { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("max_email_size")]
    public double? MaxEmailSize { get; set; }

    [Column("smtp_ssl_certificate")]
    public byte[]? SmtpSslCertificate { get; set; }

    [Column("smtp_ssl_private_key")]
    public byte[]? SmtpSslPrivateKey { get; set; }

    [Column("google_gmail_access_token_expiration")]
    public long? GoogleGmailAccessTokenExpiration { get; set; }

    [Column("google_gmail_authorization_code")]
    public string? GoogleGmailAuthorizationCode { get; set; }

    [Column("google_gmail_refresh_token")]
    public string? GoogleGmailRefreshToken { get; set; }

    [Column("google_gmail_access_token")]
    public string? GoogleGmailAccessToken { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailServer")] // One2many
    public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailServer")] // One2many
    public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailServer")] // One2many
    public virtual ICollection<MailTemplate> MailTemplate { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailServer")] // One2many
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MassMailingMailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MassMailingMailServer")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("MailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailServer")] // One2many
    public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
