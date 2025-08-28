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

[Table("fetchmail_server")]
//[Index("ServerType", Name = "fetchmail_server__server_type_index")]
//[Index("State", Name = "fetchmail_server__state_index")]
public partial class FetchmailServer: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("port")]
    public long? Port { get; set; }

    [Column("object_id")]
    public Guid? ObjectId { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("server")]
    public string? Server { get; set; }

    [Column("server_type")]
    public string? ServerType { get; set; }

    [Column("user")]
    public string? User { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("script")]
    public string? Script { get; set; }

    [Column("configuration")]
    public string? Configuration { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_ssl")]
    public bool? IsSsl { get; set; }

    [Column("attach")]
    public bool? Attach { get; set; }

    [Column("original")]
    public bool? Original { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("google_gmail_access_token_expiration")]
    public long? GoogleGmailAccessTokenExpiration { get; set; }

    [Column("google_gmail_authorization_code")]
    public string? GoogleGmailAuthorizationCode { get; set; }

    [Column("google_gmail_refresh_token")]
    public string? GoogleGmailRefreshToken { get; set; }

    [Column("google_gmail_access_token")]
    public string? GoogleGmailAccessToken { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("FetchmailServerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FetchmailServer")] // One2many
    public virtual ICollection<MailMail> MailMail { get; set; }

    // [Many2one]
    [ForeignKey("ObjectId")]
    public virtual IrModel? Object { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
