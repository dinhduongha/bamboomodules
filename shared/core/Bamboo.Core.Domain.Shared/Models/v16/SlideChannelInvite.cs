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

[Table("slide_channel_invite")]
public partial class SlideChannelInvite: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("send_email")]
    public bool? SendEmail { get; set; }

    [Column("enroll_mode")]
    public bool? EnrollMode { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("SlideChannelInvites")]
    [NotMapped]
    public virtual SlideChannel? Channel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideChannelInviteCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("SlideChannelInvites")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideChannelInviteWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("SlideChannelInviteId")]
    //[InverseProperty("SlideChannelInvites")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachments { get; set; } 

    [ForeignKey("SlideChannelInviteId")]
    //[InverseProperty("SlideChannelInvites")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 
}
