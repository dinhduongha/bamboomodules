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
//[Index("ServerType", Name = "fetchmail_server_server_type_index")]
//[Index("State", Name = "fetchmail_server_state_index")]
public partial class FetchmailServer: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("port")]
    public long? Port { get; set; }

    [Column("object_id")]
    public Guid? ObjectId { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("google_gmail_access_token_expiration")]
    public long? GoogleGmailAccessTokenExpiration { get; set; }

    [Column("google_gmail_authorization_code")]
    public string? GoogleGmailAuthorizationCode { get; set; }

    [Column("google_gmail_refresh_token")]
    public string? GoogleGmailRefreshToken { get; set; }

    [Column("google_gmail_access_token")]
    public string? GoogleGmailAccessToken { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FetchmailServerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ObjectId")]
    //[InverseProperty("FetchmailServers")]
    [NotMapped]
    public virtual IrModel? Object { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FetchmailServerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("FetchmailServer")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMails { get; } = new List<MailMail>();

}
