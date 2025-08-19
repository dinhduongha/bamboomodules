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

[Table("mail_group_message")]
//[Index("MailMessageId", Name = "mail_group_message__mail_message_id_index")]
//[Index("ModerationStatus", Name = "mail_group_message__moderation_status_index")]
public partial class MailGroupMessage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("mail_group_id")]
    public Guid? MailGroupId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("group_message_parent_id")]
    public Guid? GroupMessageParentId { get; set; }

    [Column("moderator_id")]
    public Guid? ModeratorId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_from_normalized")]
    public string? EmailFromNormalized { get; set; }

    [Column("moderation_status")]
    public string? ModerationStatus { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailGroupMessageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("GroupMessageParentId")]
    // [InverseProperty("InverseGroupMessageParent")] //Many2one
    public virtual MailGroupMessage? GroupMessageParent { get; set; }

    // [One2many]
    [ForeignKey("GroupMessageParentId")]
    [InverseProperty("GroupMessageParent")]
    public virtual ICollection<MailGroupMessage> InverseGroupMessageParent { get; set; }

    // [Many2one]
    [ForeignKey("MailGroupId")]
    // [InverseProperty("MailGroupMessage")] //Many2one
    public virtual MailGroup? MailGroup { get; set; }

    // [One2many]
    [ForeignKey("MailGroupMessageId")]
    [InverseProperty("MailGroupMessage")]
    public virtual ICollection<MailGroupMessageReject> MailGroupMessageReject { get; set; }

    // [Many2one]
    [ForeignKey("MailMessageId")]
    // [InverseProperty("MailGroupMessage")] //Many2one
    public virtual MailMessage? MailMessage { get; set; }

    // [Many2one]
    [ForeignKey("ModeratorId")]
    // [InverseProperty("MailGroupMessageModerator")] //Many2one
    public virtual ResUsers? Moderator { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailGroupMessageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
