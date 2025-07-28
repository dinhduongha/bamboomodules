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

[Module("base")]
[Table("ir_mail_server")]
//[Index("Name", Name = "ir_mail_server_name_index")]
public partial class IrMailServer: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("smtp_port")]
    public long? SmtpPort { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

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

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrMailServerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrMailServerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("MailServer")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } = new List<MailComposeMessage>();

    //[InverseProperty("MailServer")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; set; } = new List<MailMessage>();

    //[InverseProperty("MailServer")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; set; } = new List<MailTemplate>();

    //[InverseProperty("MailServer")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MailingMailings { get; set; } = new List<MailingMailing>();

    //[InverseProperty("MassMailingMailServer")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("MailServer")]
    [NotMapped]
    public virtual ICollection<SurveyInvite> SurveyInvites { get; set; } = new List<SurveyInvite>();

}
