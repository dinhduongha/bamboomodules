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

[Table("mail_group")]
public partial class MailGroup: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("access_group_id")]
    public Guid? AccessGroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("access_mode")]
    public string? AccessMode { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("moderation_notify_msg")]
    public string? ModerationNotifyMsg { get; set; }

    [Column("moderation_guidelines_msg")]
    public string? ModerationGuidelinesMsg { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("moderation")]
    public bool? Moderation { get; set; }

    [Column("moderation_notify")]
    public bool? ModerationNotify { get; set; }

    [Column("moderation_guidelines")]
    public bool? ModerationGuidelines { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AccessGroupId")]
    // [InverseProperty("MailGroup")] //Many2one
    public virtual ResGroups? AccessGroup { get; set; }

    // [Many2one]
    [ForeignKey("AliasId")]
    // [InverseProperty("MailGroup")] //Many2one
    public virtual MailAlias? Alias { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailGroupCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MailGroupId")]
    [InverseProperty("MailGroup")]
    public virtual ICollection<MailGroupMember> MailGroupMember { get; set; }

    // [One2many]
    [ForeignKey("MailGroupId")]
    [InverseProperty("MailGroup")]
    public virtual ICollection<MailGroupMessage> MailGroupMessage { get; set; }

    // [One2many]
    [ForeignKey("MailGroupId")]
    [InverseProperty("MailGroup")]
    public virtual ICollection<MailGroupModeration> MailGroupModeration { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailGroupWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailGroupId")] //Many2many
    // [InverseProperty("MailGroup")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
